using System;

namespace BulletinReport.Common.DTOs.BulletinsDTO
{
    public class ProsecutorDutyDTO
    {
        public int Id { get; set; }

        public string BulletinReportProsecutor { get; set; }//المناوب

        public DateTime PhoneAnswerTime { get; set; }

        public int CallsCount { get; set; }
        public int PublicProsecution { get; set; }
        public string PublicProsecutionAspNetId { get; set; }
        public string ProsecutorNotes { get; set; }
        public string ProsecutorShiftId { get; set; }//الشفت
        public DateTime BulletinReportTime { get; set; }

        public int ProsecutorShiftTime { get; set; }//الشفت

        //public virtual AspNetUser AspNetUser { get; set; }المناوب

        //public virtual Lookup Lookup { get; set; }الشفت
    }
}
