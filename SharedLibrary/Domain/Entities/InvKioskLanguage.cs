using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Domain.Entities
{
    public class InvKioskLanguage
    {
        public int Id { get; set; }
        public int KioskId { get; set; }
        public string Languages { get; set; }
        public string LanguageCode { get; set; }

        public InvKioskDetail Kiosk { get; set; }
    }

}
