using System;

namespace dotnet_bugtrackerapi.Dtos.Fix
{
    public class AddFixDto
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string HowFixed { get; set; }
        public int BreakageId { get; set; }
    }
}