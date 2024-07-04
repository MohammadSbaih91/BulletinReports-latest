namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LookupCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LookupCategory()
        {
            LookupCategories1 = new HashSet<LookupCategory>();
            Lookups = new HashSet<Lookup>();
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public int? LOrder { get; set; }

        public bool? IsInternal { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string FixedCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LookupCategory> LookupCategories1 { get; set; }

        public virtual LookupCategory LookupCategory1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lookup> Lookups { get; set; }
    }
}
