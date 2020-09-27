using AutoMapper;
using dotnet_bugtrackerapi.Dtos.Breakage;
using dotnet_bugtrackerapi.Dtos.Fix;
using dotnet_bugtrackerapi.Dtos.Test;
using dotnet_bugtrackerapi.Models;

namespace dotnet_bugtrackerapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Breakage, GetBreakageDto>();
            CreateMap<AddBreakageDto, Breakage>();
            CreateMap<Fix, GetFixDto>();
            CreateMap<AddFixDto, Fix>();
            CreateMap<Test, GetTestDto>();
        }
    }
}