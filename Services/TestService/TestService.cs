using System.Threading.Tasks;
using AutoMapper;
using dotnet_bugtrackerapi.Data;
using dotnet_bugtrackerapi.Dtos.Test;
using dotnet_bugtrackerapi.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_bugtrackerapi.Services.TestService
{
    public class TestService : ITestService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TestService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetTestDto>> GetTest(int id)
        {
            ServiceResponse<GetTestDto> serviceResponse = new ServiceResponse<GetTestDto>();
            Test test = await _context.Tests
                .Include(t => t.Breakages).ThenInclude(b => b.Fix)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (test == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Test not found.";
            }
            else
            {
                serviceResponse.Data = _mapper.Map<GetTestDto>(test);
            }
            return serviceResponse;
        }
    }
}