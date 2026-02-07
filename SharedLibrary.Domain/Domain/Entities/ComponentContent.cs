using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SharedLibrary.Domain.Domain.Entities
{
    public class ComponentContent
    {
        [Key]
        public int ContentId { get; set; }

        [ForeignKey(nameof(SectionComponent))]
        public int SectionComponentId { get; set; }

        [MaxLength(100)]
        public string ContentKey { get; set; }     // title, imageUrl

        public string ContentValue { get; set; }

        [MaxLength(10)]
        public string LanguageCode { get; set; }   // en, hi

        public bool IsActive { get; set; } = true;

        // Navigation
        public SectionComponent SectionComponent { get; set; }
    }
}
