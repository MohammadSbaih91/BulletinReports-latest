using System;

namespace BulletinReport.Common.DTOs.BulletinsDTO
{
    public class BulletinProcedureDTO
    {
        public int Id { get; set; }

        public int PublicProsecution { get; set; }//النيابة العامة المستلمة للبلاغ

        public DateTime ProcedureTime { get; set; }

        public string Prosecutor { get; set; }//اسم وكيل النيابة المستلم للبلاغ

        public bool? HasBeenMoved { get; set; }

        public bool? NotBeenMoved { get; set; }

        public bool? MessageBeenSent { get; set; }

        public string ProcedureCreatedBy { get; set; }

        public DateTime ProcedureCreatedAt { get; set; }

        public string ProcedureUpdatedBy { get; set; }

        public DateTime? ProcedureUpdatedAt { get; set; }

        public string ProcedureDeletedBy { get; set; }

        public DateTime? ProcedureDeletedAt { get; set; }
        public string ProcedureNotes { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; } Prosecuter اسم وكيل النيابة المستلم للبلاغ

        //public virtual AspNetUser AspNetUser1 { get; set; }ProcedureCreatedBy

        //public virtual AspNetUser AspNetUser2 { get; set; }ProcedureUpdatedBy

        //public virtual AspNetUser AspNetUser3 { get; set; }ProcedureDeletedBy

        //public virtual Lookup Lookup { get; set; }PublicProsecuter  النيابة العامة المستلمة للبلاغ
    }
}
