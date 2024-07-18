using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP04.Interfaces
{
    internal interface IAuthenticationService
    {
        #region Methods
        public bool AuthenticateUser(string username, string password);
        public bool AuthorizeUser(string username);
        #endregion
    }
}
