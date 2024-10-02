using AutoMapper;
using C42_G01_MVC_Demo.DAL.Models;
using C42_G01_MVC01_Demo.PL.ViewModels;

namespace C42_G01_MVC01_Demo.PL.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
