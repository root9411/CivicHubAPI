using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedLibrary.Domain.Domain.Entities
{
    public class Component
    {
        [Key]
        public int ComponentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ComponentType { get; set; }
        // text, image, button, form

        [MaxLength(100)]
        public string ComponentName { get; set; }

        public string DefaultConfig { get; set; } // JSON

        // Navigation
        public ICollection<SectionComponent> SectionComponents { get; set; }
    }
}
