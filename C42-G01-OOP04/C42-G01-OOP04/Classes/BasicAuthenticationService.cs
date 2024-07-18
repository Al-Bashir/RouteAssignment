using C42_G01_OOP04.Interfaces;

namespace C42_G01_OOP04.Classes
{
    internal class BasicAuthenticationService : IAuthenticationService
    {


        public bool AuthenticateUser(string username, string password)
        {
            return true;
        }

        public bool AuthorizeUser(string username)
        {
            return true;
        }
    }
}
