using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_bugtrackerapi.Dtos.Breakage;
using dotnet_bugtrackerapi.Dtos.Fix;
using dotnet_bugtrackerapi.Models;

namespace dotnet_bugtrackerapi.Services.BreakageService
{
    public interface IBreakageService
    {
         Task<ServiceResponse<List<GetBreakageDto>>> AddBreakage(AddBreakageDto newBreakage);
         Task<ServiceResponse<GetBreakageDto>> FixBreakage(int breakageId, AddFixDto fix);
         Task<ServiceResponse<GetBreakageDto>> GetBreakage(int breakageId);
         Task<ServiceResponse<List<GetBreakageDto>>> GetBreakages();
    }
}