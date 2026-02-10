using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedLibrary.Application.Application.Dtos
{
    public class LanguageListDto
    {
        public int Id { get; set; }
        public string LanguageText { get; set; }

        public string LangFlag { get; set; }

        public string LanguageCode { get; set; }

        public string config { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
