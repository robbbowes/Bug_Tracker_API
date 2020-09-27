using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_bugtrackerapi.Data;
using dotnet_bugtrackerapi.Dtos.Breakage;
using dotnet_bugtrackerapi.Dtos.Fix;
using dotnet_bugtrackerapi.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_bugtrackerapi.Services.BreakageService
{
    public class BreakageService : IBreakageService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public BreakageService(DataContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetBreakageDto>>> AddBreakage(AddBreakageDto newBreakage)
        {
            ServiceResponse<List<GetBreakageDto>> serviceResponse = new ServiceResponse<List<GetBreakageDto>>();
            Breakage breakage = _mapper.Map<Breakage>(newBreakage);

            await _context.Breakages.AddAsync(breakage);
            await _context.SaveChangesAsync();

            serviceResponse.Data = (_context.Breakages.Select(b => _mapper.Map<GetBreakageDto>(b))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBreakageDto>> FixBreakage(int breakageId, AddFixDto fix)
        {
            ServiceResponse<GetBreakageDto> serviceResponse = new ServiceResponse<GetBreakageDto>();
            Breakage breakage = await _context.Breakages
                .FirstOrDefaultAsync(b => b.Id == breakageId);
            if (breakage == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Breakage not found.";
            }
            else
            {
                breakage.Fix = _mapper.Map<Fix>(fix);

                _context.Breakages.Update(breakage);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = _mapper.Map<GetBreakageDto>(breakage);
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBreakageDto>> GetBreakage(int breakageId)
        {
            ServiceResponse<GetBreakageDto> serviceResponse = new ServiceResponse<GetBreakageDto>();
            Breakage breakage = await _context.Breakages
                .Include(b => b.Fix)
                .FirstOrDefaultAsync(b => b.Id == breakageId);
            serviceResponse.Data = _mapper.Map<GetBreakageDto>(breakage);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBreakageDto>>> GetBreakages()
        {
            ServiceResponse<List<GetBreakageDto>> serviceResponse = new ServiceResponse<List<GetBreakageDto>>();
            List<Breakage> dbBreakages = await _context.Breakages
                .Include(b => b.Fix)
                .ToListAsync();
            serviceResponse.Data = (dbBreakages.Select(b => _mapper.Map<GetBreakageDto>(b))).ToList();
            return serviceResponse;
        }
    }
}