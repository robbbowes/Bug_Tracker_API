using System.Threading.Tasks;
using dotnet_bugtrackerapi.Dtos.Test;
using dotnet_bugtrackerapi.Models;

namespace dotnet_bugtrackerapi.Services.TestService
{
    public interface ITestService
    {
         Task<ServiceResponse<GetTestDto>> GetTest(int id);
    }
}