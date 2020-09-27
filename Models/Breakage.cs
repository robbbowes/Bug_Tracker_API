using System;

namespace dotnet_bugtrackerapi.Models
{
    public class Breakage
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string BreakageReason { get; set; }
        public Fix Fix { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}