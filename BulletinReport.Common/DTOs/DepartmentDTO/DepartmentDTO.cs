using System;

namespace BulletinReport.Common.DTOs.DepartmentDTO
{
    public class DepartmentDTO
    {
        public int ID { get; set; }

        public int? Type { get; set; }

        public string Name { get; set; }

        public string Manager { get; set; }

        public int? Parent { get; set; }

        public string ActiveGroup { get; set; }

        public decimal? CaseSerial { get; set; }

        public decimal? BulletinSerial { get; set; }

        public string PrefixName { get; set; }

        public string Archive { get; set; }

        public string NameEng { get; set; }

        public bool? RFID_Enabled { get; set; }

        public bool? RFID_InActive { get; set; }

        public bool? RFID_Hidden { get; set; }
        public string FaxNo { get; set; }

        public int? FinanceID { get; set; }

        public string FinanceSource { get; set; }

        public string SearchWarrantGroup { get; set; }

        public int? GeneralProsID { get; set; }

        public int? GroupID { get; set; }

        public int? SubSourceID { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool IsActive_HT { get; set; }

        public string StampID { get; set; }

        public bool? IsBookReq { get; set; }

        public string BookReqIDs { get; set; }
    }




}
