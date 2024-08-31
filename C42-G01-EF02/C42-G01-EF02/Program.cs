using C42_G01_EF01.Context;
using C42_G01_EF01.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace C42_G01_EF01
{
    internal class Program
    {
        static void Main()
        {
            using ITIDbContext DbContext = new ITIDbContext();
            Department D1 = new Department() 
            {
                Name = "A",
            };            
            Department D2 = new Department() 
            {
                Name = "B",
            };

            Console.WriteLine($"D1 state:{DbContext.Entry(D1).State}");
            Console.WriteLine($"D2 state:{DbContext.Entry(D2).State}");
            //DbContext.Departments.Add(D1);
            //DbContext.Departments.Add(D2);

            Department? department = DbContext.Departments.Where(D => D.Id == 10).FirstOrDefault();
            Console.WriteLine($"D1 Name:{department?.Name ?? "Not Found"}");

            Instructor Inst01 = new Instructor()
            {
                Name = "Inst01",
                Salary = 1000,
                HourRate = 100,
                Address = "Inst01 Street",
                DeptId = DbContext.Departments.Where(D => D.Id == 10).Select(D => D.Id).FirstOrDefault()
            };

            Instructor Inst02 = new Instructor()
            {
                Name = "Inst02",
                Salary = 2000,
                HourRate = 200,
                Address = "Inst02 Street",
                DeptId = DbContext.Departments.Where(D => D.Id == 10).Select(D => D.Id).FirstOrDefault()
            };

            //DbContext.Instructores.Add( Inst01);
            //DbContext.Instructores.Add( Inst02);


            Instructor? instructor = DbContext.Instructores.FirstOrDefault();

            Console.WriteLine($"Inst01 Name:{instructor?.Name ?? "Not Found"}");

            if(department is not null && instructor is not null)
                department.MangerId = instructor.Id;

            Department? departmentM = DbContext.Departments.Where(D => D.Id == 10).FirstOrDefault();
            Console.WriteLine($"D1M Name:{department?.MangerId ?? 0}");

            instructor.Address = "Z3bola";

            Instructor? instructorM = DbContext.Instructores.FirstOrDefault();

            Console.WriteLine($"Inst01M Address:{instructor?.Address ?? "Not Found"}");

            //DbContext.Departments.Remove(DbContext.Departments.Where(D => D.Id == 12).FirstOrDefault());
            //DbContext.Instructores.Remove(DbContext.Instructores.Where(I => I.Id == 2).FirstOrDefault());

            DbContext.SaveChanges();


            //Console.WriteLine($"Inst01 state:{DbContext.Departments.Where(D => D.Id == 12).FirstOrDefault().Name ?? "Not Found"}");
            //Console.WriteLine($"Inst02 state:{DbContext.Instructores.Where(D => D.Id == 2).FirstOrDefault().Name ?? "Not Found"}");


            Student student01 = new Student()
            {
                FName = "ftest",
                LName = "ltest",
                Address = "atest",
                Age = 1,
                DeptId = DbContext.Departments.Where(D => D.Id == 10).FirstOrDefault().Id
            };

            Student student02 = new Student()
            {
                FName = "ftest2",
                LName = "ltest2",
                Address = "atest2",
                Age = 2,
                DeptId = DbContext.Departments.Where(D => D.Id == 10).FirstOrDefault().Id
            };

            //DbContext.Students.Add(student01);
            //DbContext.Students.Add(student02);

            DbContext.SaveChanges();
            Student RStudent = DbContext.Students.Where(S => S.Id == 2).FirstOrDefault();

            //Console.WriteLine($"Rs Name: {RStudent.FName}");

            //RStudent.FName = "Hmbozo";

            DbContext.SaveChanges();
            RStudent = DbContext.Students.Where(S => S.Id == 2).FirstOrDefault();
            Console.WriteLine($"Rs Name After Update: {RStudent?.FName ?? "Not found"}");

            //DbContext.Students.Remove(DbContext.Students.Where(S => S.Id == 2).FirstOrDefault());
            DbContext.SaveChanges();

            RStudent = DbContext.Students.Where(S => S.Id == 2).FirstOrDefault();
            Console.WriteLine($"Rs Name After Update: {RStudent?.FName ?? "Not found"}");
            Topic topic01 = new Topic()
            {
                Name = "tOPIC01",
            };

            Topic topic02 = new Topic()
            {
                Name = "tOPIC01",
            };

            //DbContext.Topics.Add(topic01);
            //DbContext.Topics.Add(topic02);

            DbContext.SaveChanges();

            Topic RTopic = DbContext.Topics.Where(T => T.Id == 2).FirstOrDefault();
            Console.WriteLine($"RT Name : {RTopic?.Name ?? "Not found"}");

            //RTopic.Name = "UName";
            DbContext.SaveChanges();

            RTopic = DbContext.Topics.Where(T => T.Id == 2).FirstOrDefault();
            Console.WriteLine($"RT Name A U : {RTopic?.Name ?? "Not found"}");

            //DbContext.Topics.Remove(DbContext.Topics.Where(T => T.Id == 2).FirstOrDefault());
            DbContext.SaveChanges();

            RTopic = DbContext.Topics.Where(T => T.Id == 2).FirstOrDefault();
            Console.WriteLine($"RT Name A R : {RTopic?.Name ?? "Not Found"}");


            Course course01 = new Course()
            { 
                Name = "Course01",
                Description = "Course01",
                Duration = "01",
                Topic = DbContext.Topics.Where(T => T.Id == 1).FirstOrDefault()
            };

            Course course02 = new Course()
            { 
                Name = "Course02",
                Description = "Course02",
                Duration = "02",
                Topic = DbContext.Topics.Where(T => T.Id == 1).FirstOrDefault()
            };

            //DbContext.Courses.Add(course01);
            //DbContext.Courses.Add(course02);

            DbContext.SaveChanges();
            
            Course RCourse = DbContext.Courses.Where(C => C.AnyThing == 2).FirstOrDefault();
            Console.WriteLine($"RC Name : {RCourse?.Name ?? "Not found"}");

            //RCourse.Name = "UCoures";
            DbContext.SaveChanges();

            RCourse = DbContext.Courses.Where(C => C.AnyThing == 2).FirstOrDefault();
            Console.WriteLine($"RC Name A U : {RCourse?.Name ?? "Not found"}");

            //DbContext.Courses.Remove(DbContext.Courses.Where(C => C.AnyThing == 2).FirstOrDefault());

            CourseInstructor courseInstructor = new CourseInstructor()
            { 
                CourseId = DbContext.Courses.Where(C => C.AnyThing == 1).FirstOrDefault().AnyThing,
                InstructorId = DbContext.Instructores.FirstOrDefault().Id,
                Evaluate = 90
            };

            StudentCourse studentCourse = new StudentCourse()
            { 
                StudentId = DbContext.Students.Where(S => S.Id == 1).FirstOrDefault().Id,
                CourseId = DbContext.Courses.Where(C => C.AnyThing == 1).FirstOrDefault().AnyThing,
                Grade = 100
            };

            //DbContext.Add(courseInstructor);
            //DbContext.Add(studentCourse);
            
            DbContext.SaveChanges();

            //Console.WriteLine($"Instructor per course: {DbContext.CourseInstructors.Select(IC => IC.Instructor).FirstOrDefault().Name}");
            //Console.WriteLine($"Coures per Instractor: {DbContext.CourseInstructors.Select(IC => IC.Course).FirstOrDefault().Name}");
            var RInstCourse = DbContext.Courses.Include(C => C.CourseInstructors).ThenInclude(IC => IC.Instructor).FirstOrDefault(C => C.Name == "Course01");
            Console.WriteLine($"Select Instructor of specific Coures: {RInstCourse.CourseInstructors.Select(CI => CI.Instructor).FirstOrDefault().Address}");

        }
    }
}
