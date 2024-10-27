using AutoMapper;
using C42_G01_MVC01_Demo.PL.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace C42_G01_MVC01_Demo.PL.MappingProfiles
{
    public class IdentityRoleProfile : Profile
    {
        public IdentityRoleProfile() 
        {
            CreateMap<IdentityRole, IdentityRoleViewModel>().ReverseMap();   
        }
    }
}
