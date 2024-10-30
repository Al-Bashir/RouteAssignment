using System.Collections.Generic;

namespace C42_G01_MVC01_Demo.PL.ViewModels
{
    public class RoleUsersViewModel
    {
        public IdentityRoleViewModel Role { get; set; }
        public IEnumerable<LightUserViewModel> Users { get; set; }
    }
}
