namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            UserDepartments = new HashSet<UserDepartment>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string LogonName { get; set; }

        public int? Department { get; set; }

        public int? PoliceOfficeID { get; set; }

        [StringLength(100)]
        public string DefaultGroup { get; set; }

        public int? GroupID { get; set; }

        public int? SectionID { get; set; }

        [StringLength(50)]
        public string Assistant { get; set; }

        [StringLength(50)]
        public string CorrespDefaultGroup { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EmpCode { get; set; }

        public byte? Deleted { get; set; }

        public long Rank { get; set; }

        public int RankOrder { get; set; }

        public int? HRID { get; set; }

        [StringLength(500)]
        public string SearchFilter { get; set; }

        [StringLength(500)]
        public string AttSearchFilter { get; set; }

        public bool? RfidEnabled { get; set; }

        [StringLength(50)]
        public string PhoneExt { get; set; }

        [StringLength(100)]
        public string Role { get; set; }

        [StringLength(50)]
        public string RoleID { get; set; }

        [StringLength(800)]
        public string ADGroupsList { get; set; }

        public int? HR_EmploymentStatusID { get; set; }

        [StringLength(250)]
        public string HR_EmployeeTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserDepartment> UserDepartments { get; set; }
    }
}
