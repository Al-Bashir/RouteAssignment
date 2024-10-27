using System;

namespace C42_G01_MVC01_Demo.PL.ViewModels
{
    public class IdentityRoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IdentityRoleViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
