using System.Threading.Tasks;
using AutoMapper;
using dotnet_bugtrackerapi.Data;
using dotnet_bugtrackerapi.Dtos.Breakage;
using dotnet_bugtrackerapi.Dtos.Fix;
using dotnet_bugtrackerapi.Services.BreakageService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_bugtrackerapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreakageController : ControllerBase
    {
        private readonly IBreakageService _breakagesService;

        public BreakageController(IBreakageService breakagesService)
        {
            this._breakagesService = breakagesService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBreakage(AddBreakageDto newBreakage)
        {
            return Ok(await _breakagesService.AddBreakage(newBreakage));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> FixBreakage(int id, AddFixDto fix)
        {
            return Ok(await _breakagesService.FixBreakage(id, fix));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBreakage(int id)
        {
            return Ok(await _breakagesService.GetBreakage(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetBreakages()
        {
            return Ok(await _breakagesService.GetBreakages());
        }
    }
}