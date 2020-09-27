using System.Collections.Generic;
using dotnet_bugtrackerapi.Dtos.Breakage;

namespace dotnet_bugtrackerapi.Dtos.Test
{
    public class GetTestDto
    {
        public string Name { get; set; }
        public bool IsBroken { get; set; }
        public List<GetBreakageDto> Breakages { get; set; }
    }
}