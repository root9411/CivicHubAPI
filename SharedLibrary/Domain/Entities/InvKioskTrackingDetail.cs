using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Domain.Entities
{
    public class InvKioskTrackingDetail
    {
        public int Id { get; private set; }

        public int KioskId { get; private set; }
        public InvKioskDetail Kiosk { get; private set; }

        public int SessionUserId { get; private set; }
        public InvKioskSessionUser SessionUser { get; private set; }

        public int? KioskServiceId { get; private set; }
        public KioskService KioskService { get; private set; }

        public DateTime SessionStartTime { get; private set; }
        public DateTime? SessionEndTime { get; private set; }

        public string SessionActivity { get; private set; }

        protected InvKioskTrackingDetail() { } // EF Core

        public InvKioskTrackingDetail(
            int kioskId,
            int sessionUserId,
            int? kioskServiceId,
            string sessionActivity)
        {
            KioskId = kioskId;
            SessionUserId = sessionUserId;
            KioskServiceId = kioskServiceId;

            SessionStartTime = DateTime.UtcNow;
            SessionActivity = sessionActivity;
        }

        public void EndSession(string finalActivity)
        {
            SessionEndTime = DateTime.UtcNow;
            SessionActivity = finalActivity;
        }
    }
}
