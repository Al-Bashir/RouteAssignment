using C42_G01_OOP04.Classes;
using C42_G01_OOP04.Interfaces;

namespace C42_G01_OOP04
{
    internal class Program
    {
        static void Main()
        {
            #region Part 01 
            //Question 1:
            //What is the primary purpose of an interface in C#?
            //  a) To provide a way to implement multiple inheritance

            //Question 2:
            //Which of the following is NOT a valid access modifier for interface members in C#?
            //  a) private
            //  b) protected
            //  c) internal

            //Question 3:
            //Can an interface contain fields in C#?
            //  b) No

            //Question 4:
            //In C#, can an interface inherit from another interface?
            //  b) Yes, interfaces can inherit from multiple interfaces

            //Question 5:
            //Which keyword is used to implement an interface in a class in C#?
            //  d) implements => Symbol (:) 

            //Question 6:
            //Can an interface contain static methods in C#?
            //  a) Yes

            //Question 7:
            //In C#, can an interface have explicit access modifiers for its members?
            //  b) No, all members are implicitly public

            //Question 8:
            //What is the purpose of an explicit interface implementation in C#?
            //  b) To provide a clear separation between interface and class members

            //Question 9:
            //In C#, can an interface have a constructor?
            //  b) No, interfaces cannot have constructors

            //Question 10:
            // How can a C# class implement multiple interfaces?
            //  c) By separating interface names with commas
            #endregion

            #region Part 02 - Question 01:
            Rectangle rectangle = new Rectangle(200);
            rectangle.DisplayShapeInfo();

            Circle circle = new Circle(100);
            circle.DisplayShapeInfo();
            #endregion

            #region Part 02 - Question 02:
            IAuthenticationService authService =  new BasicAuthenticationService();

            authService.AuthenticateUser("Ahmed", "HashPassword");

            authService.AuthorizeUser("Ahmed");


            #endregion

            #region Part 02 - Question 03: 
            EmailNotificationService emailNotificationService  = new EmailNotificationService();
            emailNotificationService.SendNotification("Ahmed", "Notification Using Email Notification");

            PushNotificationService pushNotificationService = new PushNotificationService();
            pushNotificationService.SendNotification("Ali", "Notification Using Push Notification");

            SmsNotificationService smsNotificationService = new SmsNotificationService();
            smsNotificationService.SendNotification("Omar", "Notification Using SMS Notification");
            #endregion
        }
    }
}
