using BulletinReport.Common.App_LocalResources;

using System;
using System.ComponentModel.DataAnnotations;

namespace BulletinReports.Models.BulletinsViewModel
{
    public class BulletinProcedureViewModel
    {
        public int Id { get; set; }

        public int PublicProsecution { get; set; }//PublicProsecuter  النيابة العامة المستلمة للبلاغ
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        [DataType(DataType.Time)]
        public TimeSpan ProcedureTime { get; set; }

        public string Prosecutor { get; set; }//اسم وكيل النيابة المستلم للبلاغ

        public bool? HasBeenMoved { get; set; }

        public bool? NotBeenMoved { get; set; }

        public string ProcedureCreatedBy { get; set; }

        public DateTime ProcedureCreatedAt { get; set; }

        public string ProcedureUpdatedBy { get; set; }

        public DateTime? ProcedureUpdatedAt { get; set; }

        public string ProcedureDeletedBy { get; set; }

        public DateTime? ProcedureDeletedAt { get; set; }

        public string ProcedureNotes { get; set; }

    }
}