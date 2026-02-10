using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Domain.Domain.Entities
{
    public class ElectricityBoard
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string BoardName { get; set; }
        public string? DistrictOrType { get; set; }

        public bool ConsumerNumber { get; set; }
        public bool ServiceNumber { get; set; }
        public bool ConnectionNumber { get; set; }
        public bool TenantNumber { get; set; }
    }
}
