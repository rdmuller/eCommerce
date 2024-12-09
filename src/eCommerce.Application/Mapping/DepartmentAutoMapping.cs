using AutoMapper;
using eCommerce.Application.DTOs.Departments;
using eCommerce.Domain.Entites;

namespace eCommerce.Application.Mapping;
public class DepartmentAutoMapping : Profile
{
    public DepartmentAutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void EntityToResponse()
    {
        CreateMap<Department, DepartmentSimpleQueryDTO>()
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(source => source.Id))
            .ForMember(d => d.DepartmentName, cfg => cfg.MapFrom(s => s.Name));

        CreateMap<Department, DepartmentFullQueryDTO>()
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(source => source.Id))
            .ForMember(d => d.DepartmentName, opt => opt.MapFrom(s => s.Name));
    }

    private void RequestToEntity()
    {
        CreateMap<DepartmentCommandDTO, Department>()
            .ConstructUsing(src => new Department(0, src.Name));
    }
}
