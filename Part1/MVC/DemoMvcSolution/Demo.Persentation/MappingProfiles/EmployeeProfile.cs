using AutoMapper;
using Demo.DataAccessLayer.Models;
using Demo.Persentation.ViewModels;

namespace Demo.Persentation.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
