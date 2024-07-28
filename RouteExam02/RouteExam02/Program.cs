using RouteExam02.Classes;

namespace RouteExam02
{
    internal class Program
    {
        static void Main()
        {
            Subject subject = new Subject(1, "Science");
            subject.InitiateSubjectExam();
        }
    }
}
