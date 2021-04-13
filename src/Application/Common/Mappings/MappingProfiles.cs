using System.Linq;
using AutoMapper;
using ORRA.Application.Companies.Queries;
using ORRA.Domain.Entities;

namespace ORRA.Application.Common.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(d => d.Departments, o => o.MapFrom(s => s.Departments));

            CreateMap<Department, DepartmentDto>();
        }
    }
}