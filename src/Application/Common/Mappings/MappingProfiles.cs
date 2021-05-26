using System.Linq;
using AutoMapper;
using ORRAS.Application.Companies.Queries;
using ORRAS.Application.Features.ResearchStudies.Queries;
using ORRAS.Domain.Entities;

namespace ORRAS.Application.Common.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(d => d.Departments, o => o.MapFrom(s => s.Departments));

            CreateMap<Department, DepartmentDto>();
            CreateMap<ResearchStudy, ResearchStudyDto>();
        }
    }
}