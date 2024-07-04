namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bulletin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bulletin()
        {
            Procedures = new HashSet<Procedure>();
            ProsecutorDuties = new HashSet<ProsecutorDuty>();
        }

        public int Id { get; set; }

        [Required]
        public string BulletinPoName { get; set; }

        [Required]
        public string BulletinPoNumber { get; set; }

        [Required]
        public string AccedentNumber { get; set; }

        public int PoliceOffice { get; set; }

        public DateTime ReportDate { get; set; }

        public int OfficerRank { get; set; }

        [Required]
        public string OfficerPhoneNumber { get; set; }

        public int BulletinType { get; set; }

        [Required]
        public string BulletinDescription { get; set; }

        [Required]
        public string PartyName { get; set; }

        public int PartyAge { get; set; }

        public long PartyQatariId { get; set; }

        public int PartyNationality { get; set; }

        public string PartyOtherDescription { get; set; }

        [Required]
        public string BulletinNameAr { get; set; }

        [Required]
        public string PartyNameAr { get; set; }

        [Required]
        [StringLength(128)]
        public string BulletinCreatedBy { get; set; }

        public DateTime BulletinCreatedAt { get; set; }

        [StringLength(128)]
        public string BulletinUpdatedBy { get; set; }

        public DateTime? BulletinUpdatedAt { get; set; }

        [StringLength(128)]
        public string BulletinDeletedBy { get; set; }

        public DateTime? BulletinDeletedAt { get; set; }

        public int Department { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsUpdated { get; set; }

        public virtual Lookup Lookup { get; set; }

        public virtual Lookup Lookup1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Procedure> Procedures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProsecutorDuty> ProsecutorDuties { get; set; }
    }
}
