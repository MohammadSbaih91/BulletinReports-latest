namespace BulletinReport.Common.DTOs
{
    public class UsersDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string LogonName { get; set; }

        public int? Department { get; set; }

        public int? PoliceOfficeID { get; set; }

        public string DefaultGroup { get; set; }

        public int? GroupID { get; set; }

        public int? SectionID { get; set; }

        public string Assistant { get; set; }

        public string CorrespDefaultGroup { get; set; }

        public decimal? EmpCode { get; set; }

        public byte? Deleted { get; set; }

        public long Rank { get; set; }

        public int RankOrder { get; set; }

        public int? HRID { get; set; }

        public string SearchFilter { get; set; }

        public string AttSearchFilter { get; set; }

        public bool? RfidEnabled { get; set; }

        public string PhoneExt { get; set; }

        public string Role { get; set; }

        public string RoleID { get; set; }

        public string ADGroupsList { get; set; }

        public int? HR_EmploymentStatusID { get; set; }

        public string HR_EmployeeTitle { get; set; }

        //public int AttachmentRoleID { get; set; }

    }
}
