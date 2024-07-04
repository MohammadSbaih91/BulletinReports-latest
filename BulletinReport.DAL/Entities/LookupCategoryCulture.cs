namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LookupCategoryCulture
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LookupCategoryID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CultureID { get; set; }

        [Required]
        [StringLength(250)]
        public string Value { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }
    }
}
