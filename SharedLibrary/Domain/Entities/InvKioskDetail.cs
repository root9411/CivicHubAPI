using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Domain.Entities
{
    public class InvKioskDetail
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string IPAddress { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<KioskLanguage> Languages { get; set; }
        public ICollection<KioskService> Services { get; set; }


        protected InvKioskDetail() { }

        // Domain constructor
        public InvKioskDetail(string location, string ipAddress)
        {
            Location = location;
            IPAddress = ipAddress;
            IsActive = true;
            CreationDate = DateTime.UtcNow;
        }


    }
}
