using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Application.Application.Dtos
{
    public class PageDto
    {
        public string PageKey { get; set; }
        public List<ComponentDto> Components { get; set; }
    }

    public class ComponentDto
    {
        public string Type { get; set; }
        public int Order { get; set; }
        public Dictionary<string, string> Text { get; set; }
        public Dictionary<string, object> Config { get; set; }
    }
}
