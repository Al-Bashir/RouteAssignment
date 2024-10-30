using AutoMapper;
using C42_G01_MVC_Demo.DAL.Models;
using C42_G01_MVC01_Demo.PL.ViewModels;

namespace C42_G01_MVC01_Demo.PL.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();

            CreateMap<ApplicationUser, LightUserViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FName + " " + src.LName)).ReverseMap();
        }
    }
}
