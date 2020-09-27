using System.Collections.Generic;

namespace dotnet_bugtrackerapi.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Test> Tests { get; set; }
    }
}