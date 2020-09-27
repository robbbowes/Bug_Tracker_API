using System.Collections.Generic;

namespace dotnet_bugtrackerapi.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsBroken { get; set; }
        public List<Breakage> Breakages { get; set; }
    }
}