using System.Collections.Generic;

namespace dotnet_bugtrackerapi.Models
{
    public class CodeLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Package> Packages { get; set; }
    }
}