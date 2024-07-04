namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? Type { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Manager { get; set; }

        public int? Parent { get; set; }

        [StringLength(50)]
        public string ActiveGroup { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CaseSerial { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BulletinSerial { get; set; }

        [StringLength(50)]
        public string PrefixName { get; set; }

        [StringLength(50)]
        public string Archive { get; set; }

        [StringLength(50)]
        public string NameEng { get; set; }

        public bool? RFID_Enabled { get; set; }

        public bool? RFID_InActive { get; set; }

        public bool? RFID_Hidden { get; set; }

        [StringLength(200)]
        public string FaxNo { get; set; }

        public int? FinanceID { get; set; }

        [StringLength(50)]
        public string FinanceSource { get; set; }

        [StringLength(50)]
        public string SearchWarrantGroup { get; set; }

        public int? GeneralProsID { get; set; }

        public int? GroupID { get; set; }

        public int? SubSourceID { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool IsActive_HT { get; set; }

        [StringLength(50)]
        public string StampID { get; set; }

        public bool? IsBookReq { get; set; }

        public string BookReqIDs { get; set; }
    }
}
