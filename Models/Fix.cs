using System;

namespace dotnet_bugtrackerapi.Models
{
    public class Fix
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string HowFixed { get; set; }
        public int BreakageId { get; set; }
        public Breakage Breakage { get; set; }
    }
}