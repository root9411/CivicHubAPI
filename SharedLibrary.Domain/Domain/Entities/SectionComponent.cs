using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SharedLibrary.Domain.Domain.Entities
{
    public class SectionComponent
    {
        [Key]
        public int SectionComponentId { get; set; }

        [ForeignKey(nameof(PageSection))]
        public int SectionId { get; set; }

        [ForeignKey(nameof(Component))]
        public int ComponentId { get; set; }

        public int SortOrder { get; set; }

        public string? Config { get; set; } // JSON overrides

        // Navigation
        public PageSection PageSection { get; set; }
        public Component Component { get; set; }

        public ICollection<ComponentContent> ComponentContents { get; set; }
    }
}
