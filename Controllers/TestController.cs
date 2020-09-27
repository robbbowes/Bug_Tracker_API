using System.Threading.Tasks;
using dotnet_bugtrackerapi.Services.TestService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_bugtrackerapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTest(int id)
        {
            return Ok(await _testService.GetTest(id));
        }
    }
}