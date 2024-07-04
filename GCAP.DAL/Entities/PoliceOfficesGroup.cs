namespace GCAP.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PoliceOfficesGroup
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(200)]
        public string Administration { get; set; }

        [Required]
        [StringLength(200)]
        public string ADGroup { get; set; }

        public bool IsSecurityDept { get; set; }

        [StringLength(200)]
        public string Description_En { get; set; }

        [StringLength(200)]
        public string Administration_En { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
