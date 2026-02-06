using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Domain.Entities
{
    public class InvKioskService
    {
        public int Id { get; set; }
        public int KioskId { get; set; }
        public int DepartmentId { get; set; }
        public string ServiceName { get; set; }
    }

}
