namespace GCAP.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CodingTablesData")]
    public partial class CodingTablesData
    {
        public int ID { get; set; }

        public int CodeTableID { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public bool CanDelete { get; set; }

        public bool? Fixed { get; set; }

        public bool? IsActingMemberRequired { get; set; }

        public bool? IsDescRequired { get; set; }

        public bool? IsDateRequired { get; set; }

        public bool? RFID_Enabled { get; set; }

        public bool? RFID_InActive { get; set; }

        public bool? RFID_Hidden { get; set; }

        public int? FinanceID { get; set; }

        [StringLength(50)]
        public string FinanceSource { get; set; }

        public bool? IsActive { get; set; }

        public bool? MlHighRisk { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(255)]
        public string DescriptionEn { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        [StringLength(255)]
        public string DisplayNameAr { get; set; }

        [StringLength(255)]
        public string DescriptionAr { get; set; }

        [StringLength(255)]
        public string DisplayNameEn { get; set; }

        public virtual CodingTable CodingTable { get; set; }
    }
}
