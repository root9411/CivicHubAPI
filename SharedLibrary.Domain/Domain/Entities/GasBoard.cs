using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedLibrary.Domain.Domain.Entities
{
    public class GasBoard
    {
      
        public int Id { get; set; }

        public string ProviderName { get; set; } = string.Empty;

        public string? District { get; set; }

        public string? SubDistrict { get; set; }

        public bool IsBusinessPartnerNumber { get; set; }

        public bool IsCANumber { get; set; }

        public bool IsCustomerId { get; set; }

        public bool IsBPNumber { get; set; }

        public bool IsCustomerNumber { get; set; }

        public bool IsCIDNumber { get; set; }

        public bool IsCRNNumber { get; set; }
    }
}
