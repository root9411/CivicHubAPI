using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedLibrary.Domain.Domain.Entities
{
    public class InvLanguageList
    {
        [Key]
        public int Id { get; set; }

       
        [MaxLength(255)]
        public string LanguageText { get; set; } 

        public string LangFlag { get; set; }

        public string LanguageCode { get; set; }  
        public string config { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
