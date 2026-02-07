using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SharedLibrary.Domain.Domain.Entities
{
    public class PageSection
    {
        [Key]
        public int SectionId { get; set; }

        [ForeignKey(nameof(InvPage))]
        public int PageId { get; set; }

        [MaxLength(100)]
        public string SectionKey { get; set; }  // hero, footer

        public int SortOrder { get; set; }

        [MaxLength(200)]
        public string CssClass { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation
        public InvPage InvPage { get; set; }
        public ICollection<SectionComponent> SectionComponents { get; set; }
    }
}
