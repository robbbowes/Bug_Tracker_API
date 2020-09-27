using System;
using dotnet_bugtrackerapi.Dtos.Fix;

namespace dotnet_bugtrackerapi.Dtos.Breakage
{
    public class GetBreakageDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string BreakageReason { get; set; }
        public GetFixDto Fix { get; set; }
    }
}