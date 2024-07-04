using BulletinReport.Common.DTOs;
using BulletinReport.Common.DTOs.LookupsDTO;
using BulletinReport.DAL.Entities;
using System;
using System.Collections.Generic;

namespace BulletinReports.Models.BulletinsViewModel
{
    public class ProsecutorDutyViewModel
    {
        public ProsecutorDutyViewModel()
        {
            Prosecutors = new List<UsersDTO>();
            ProsecutorList = new List<User>();
            ShiftTime = new List<LookupsDTO>();
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public string BulletinReportProsecutor { get; set; }//المناوب

        public DateTime PhoneAnswerTime { get; set; }
        public int CallsCount { get; set; }

        public string ProsecutorNotes { get; set; }

        public DateTime BulletinReportTime { get; set; }
        public int? PublicProsecutionId { get; set; }
        public string ProsecutorShiftId { get; set; }//الشفت
        public string ProsecutorShiftTime { get; set; }//الشفت

        public IEnumerable<LookupsDTO> ShiftTime { get; set; }
        public IEnumerable<LookupsDTO> PublicProsecutions { get; set; }

        public IList<UsersDTO> Prosecutors { get; set; }
        public IList<User> ProsecutorList { get; set; }
        //public virtual AspNetUser AspNetUser { get; set; }المناوب

        //public virtual Lookup Lookup { get; set; }الشفت
    }
}