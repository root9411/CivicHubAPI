using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Domain.Entities
{
    public class InvKioskSessionUser
    {
        public int Id { get; private set; }
        public string UserPhoneNo { get; private set; }
        public int UserActiveCount { get; private set; }
        public DateTime UserLastSession { get; private set; }

        public ICollection<InvKioskTrackingDetail> TrackingDetails { get; private set; }

        protected InvKioskSessionUser() { } // EF Core

        public InvKioskSessionUser(string userPhoneNo)
        {
            UserPhoneNo = userPhoneNo;
            UserActiveCount = 1;
            UserLastSession = DateTime.UtcNow;

            TrackingDetails = new HashSet<InvKioskTrackingDetail>();
        }

        public void UpdateSession()
        {
            UserActiveCount++;
            UserLastSession = DateTime.UtcNow;
        }
    }
}
