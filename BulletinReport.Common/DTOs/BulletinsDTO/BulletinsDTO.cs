using System;
using System.Collections.Generic;

namespace BulletinReport.Common.DTOs.BulletinsDTO
{
    public class BulletinsDTO
    {
        public int Id { get; set; }

        public string BulletinPoName { get; set; }

        public string BulletinPoNumber { get; set; }

        public string AccedentNumber { get; set; }

        public int Department { get; set; }

        public int PoliceOffice { get; set; }

        public DateTime ReportDate { get; set; }

        public int OfficerRank { get; set; }

        public string OfficerPhoneNumber { get; set; }

        public int BulletinType { get; set; }

        public string BulletinDescription { get; set; }

        public string PartyName { get; set; }

        public int PartyAge { get; set; }

        public long PartyQatariId { get; set; }

        public int PartyNationality { get; set; }

        public string PartyOtherDescription { get; set; }
        public string BulletinNameAr { get; set; }

        public string PartyNameAr { get; set; }

        public string BulletinCreatedBy { get; set; }
        public string PoliceOfficeName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime BulletinCreatedAt { get; set; }

        public string BulletinUpdatedBy { get; set; }

        public DateTime? BulletinUpdatedAt { get; set; }

        public string BulletinDeletedBy { get; set; }

        public DateTime? BulletinDeletedAt { get; set; }
        public BulletinProcedureDTO Procedures { get; set; }

        public List<ProsecutorDutyDTO> ProsecutorDuties { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }//created by 
        //public virtual AspNetUser AspNetUser1 { get; set; }// updated by
        //public virtual AspNetUser AspNetUser2 { get; set; }// deleted by
        //public virtual Lookup Lookup { get; set; }//police department 
        //public virtual Lookup Lookup1 { get; set; }//Bulletin Type
        //public virtual Lookup Lookup2 { get; set; }// Officer Rank
        //public virtual Lookup Lookup3 { get; set; }//Party Nationality
    }
}
