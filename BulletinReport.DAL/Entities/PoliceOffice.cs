namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PoliceOffice
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string PrefixName { get; set; }

        public bool? RFID_Enabled { get; set; }

        public bool? RFID_InActive { get; set; }

        public bool? RFID_Hidden { get; set; }

        [StringLength(50)]
        public string searchwarrantgroup { get; set; }

        public int? Corresp_ID { get; set; }

        [StringLength(200)]
        public string DisplayName { get; set; }

        public bool Active { get; set; }

        [StringLength(200)]
        public string DisplayNameEn { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? SJC_DepartmentID { get; set; }
    }
}
