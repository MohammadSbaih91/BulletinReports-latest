namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Culture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Culture()
        {
            LookupCultures = new HashSet<LookupCulture>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CultureID { get; set; }

        [Required]
        [StringLength(50)]
        public string CultureName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LookupCulture> LookupCultures { get; set; }
    }
}
