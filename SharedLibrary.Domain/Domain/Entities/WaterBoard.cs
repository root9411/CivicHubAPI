using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Domain.Domain.Entities
{
    public class WaterBoard
    {
        public int Id { get; set; }
        public string BoardName { get; set; }
        public string? ServiceType { get; set; }

        public bool ConsumerId { get; set; }
        public bool RRNumber { get; set; }
        public bool AccountNo { get; set; }
        public bool BillNumber { get; set; }
        public bool MobileNo { get; set; }
        public bool SequenceNo { get; set; }
        public bool ConnectionNo { get; set; }
        public bool ApplicationNo { get; set; }
        public bool CustomerId { get; set; }
        public bool KNumber { get; set; }
        public bool WaterTaxNo { get; set; }
        public bool TapNo { get; set; }
    }
}
