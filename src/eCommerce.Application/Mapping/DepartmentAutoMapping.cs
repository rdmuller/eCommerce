using AutoMapper;
using eCommerce.Application.DTOs.Departments;
using eCommerce.Domain.Entites;

namespace eCommerce.Application.Mapping;
public class DepartmentAutoMapping : Profile
{
    public DepartmentAutoMapping()
    {
        CreateMap<Department, DepartmentQueryDTO>()
            .ForMember(dest => dest.DepartmentId, config => config.MapFrom(source => source.Id))
            .ForMember(d => d.DepartmentName, cfg => cfg.MapFrom(s => s.Name));
    }
}
