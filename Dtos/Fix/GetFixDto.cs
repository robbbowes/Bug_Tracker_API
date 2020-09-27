using System;

namespace dotnet_bugtrackerapi.Dtos.Fix
{
    public class GetFixDto
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string HowFixed { get; set; }
    }
}