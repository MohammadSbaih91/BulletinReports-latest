using BulletinReport.Common.App_LocalResources;
using BulletinReport.Common.DTOs;
using BulletinReport.Common.DTOs.DepartmentDTO;
using BulletinReport.Common.DTOs.LookupsDTO;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BulletinReports.Models.BulletinsViewModel
{
    public class BulletinViewModel
    {

        public BulletinViewModel()
        {
            ProsecutorDuties = new List<ProsecutorDutyViewModel>();
            // Initialize other lists if necessary
        }
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public string BulletinPoName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public string BulletinPoNumber { get; set; }
        //[Range(typeof(bool), "true", "true", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public string AccedentNumber { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        //[RegularExpression(@"[0-9]{12,15}", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "IncorrectNumber")]
        public int PoliceOffice { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public string ReportDate { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public string ReportTime { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        //[RegularExpression(@"[0-9]{12,15}", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "IncorrectNumber")]
        public int OfficerRank { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public string OfficerPhoneNumber { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public int BulletinType { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        //[RegularExpression(@"^[a-z .A-Z]+$", ErrorMessage = "الرجاء إدخال الحروف الهجائية فقط")]
        public string BulletinDescription { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        //[RegularExpression(@"^[a-z .A-Z]+$", ErrorMessage = "الرجاء إدخال الحروف الهجائية فقط")]
        public string PartyOtherDescription { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public string PartyName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        //[RegularExpression(@"[0-9]{12,15}", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "IncorrectNumber")]
        public int PartyAge { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        //[RegularExpression(@"[0-9]{12,15}", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "IncorrectNumber")]
        public long PartyQatariId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public int PartyNationality { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public string BulletinNameAr { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public string PartyNameAr { get; set; }
        public int DepartmentUser { get; set; }
        public string BulletinCreatedBy { get; set; }
        public DateTime BulletinCreatedAt { get; set; }

        public string BulletinUpdatedBy { get; set; }

        public DateTime? BulletinUpdatedAt { get; set; }

        public string BulletinDeletedBy { get; set; }

        public DateTime? BulletinDeletedAt { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
        public string FilePath { get; set; }

        public string DeletedBy { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required")]
        public int Department { get; set; }
        public string PoliceOfficeName { get; set; }
        public string DepartmentName { get; set; }
        public List<ProsecutorDutyViewModel> ProsecutorDuties { get; set; }
        public BulletinProcedureViewModel Procedures { get; set; }
        public IEnumerable<PoliceOfficeDTO> PoliceOffices { get; set; }
        public IEnumerable<LookupsDTO> BulletinTypes { get; set; }
        public IEnumerable<LookupsDTO> OfficerRanks { get; set; }
        public IEnumerable<NationalitiesDTO> PartyNationalities { get; set; }
        public IEnumerable<DepartmentDTO> Departments { get; set; }
        public IList<UsersDTO> DepartmentUsers { get; set; }


        //public virtual AspNetUser AspNetUser { get; set; }//created by 
        //public virtual AspNetUser AspNetUser1 { get; set; }// updated by
        //public virtual AspNetUser AspNetUser2 { get; set; }// deleted by
        //public virtual Lookup Lookup { get; set; }//police department 
        //public virtual Lookup Lookup1 { get; set; }//Bulletin Type
        //public virtual Lookup Lookup2 { get; set; }// Officer Rank
        //public virtual Lookup Lookup3 { get; set; }//Party Nationality
    }
}