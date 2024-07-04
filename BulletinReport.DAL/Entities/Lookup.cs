namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lookup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lookup()
        {
            Bulletins = new HashSet<Bulletin>();
            Bulletins1 = new HashSet<Bulletin>();
            LookupCultures = new HashSet<LookupCulture>();
            Lookups1 = new HashSet<Lookup>();
            LookupsMappings = new HashSet<LookupsMapping>();
            NotificaitonsHistories = new HashSet<NotificaitonsHistory>();
            Notifications = new HashSet<Notification>();
            Notifications1 = new HashSet<Notification>();
            Procedures = new HashSet<Procedure>();
            ProsecutorDuties = new HashSet<ProsecutorDuty>();
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        public int CategoryId { get; set; }

        [StringLength(100)]
        public string LookupCode { get; set; }

        public bool IsActive { get; set; }

        public bool IsInternal { get; set; }

        public int? LOrder { get; set; }

        public int? Sequance { get; set; }

        public bool IsDefault { get; set; }

        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bulletin> Bulletins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bulletin> Bulletins1 { get; set; }

        public virtual LookupCategory LookupCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LookupCulture> LookupCultures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lookup> Lookups1 { get; set; }

        public virtual Lookup Lookup1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LookupsMapping> LookupsMappings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotificaitonsHistory> NotificaitonsHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notifications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notifications1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Procedure> Procedures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProsecutorDuty> ProsecutorDuties { get; set; }
    }
}
