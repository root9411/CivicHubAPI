using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedLibrary.Domain.Domain.Entities
{
    public class InvPage
    {
        [Key]
        public int PageId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PageKey { get; set; }   // home, about

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Route { get; set; }     // /home, /about

        [MaxLength(50)]
        public string Layout { get; set; }    // default, full-width

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public ICollection<PageSection> PageSections { get; set; }
    }
}
