using AutoMapper;
using ORRAS.Application.Features.Companies.Commands;
using ORRAS.Application.Features.Companies.Queries;
using ORRAS.Application.Features.ResearchStudies.Queries;
using ORRAS.Domain.Entities;

namespace ORRAS.Application.Common.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<NewCompanyDto, Company>();
            
            CreateMap<Company, CompanyDto>()
                .ForMember(d => d.Departments, o => o.MapFrom(s => s.Departments));

            CreateMap<Department, DepartmentDto>();
            CreateMap<ResearchStudy, ResearchStudyDto>();
        }
    }
}