using System;
using dotnet_bugtrackerapi.Dtos.Fix;

namespace dotnet_bugtrackerapi.Dtos.Breakage
{
    public class AddBreakageDto
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string BreakageReason { get; set; }
        public AddFixDto Fix { get; set; }
    }
}