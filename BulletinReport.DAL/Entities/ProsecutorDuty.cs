namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProsecutorDuty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProsecutorDuty()
        {
            Bulletins = new HashSet<Bulletin>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string BulletinReportProsecutor { get; set; }

        [Column(TypeName = "date")]
        public DateTime PhoneAnswerTime { get; set; }

        public int CallsCount { get; set; }

        public string ProsecutorNotes { get; set; }

        [Column(TypeName = "date")]
        public DateTime BulletinReportTime { get; set; }

        public int ProsecutorShiftTime { get; set; }

        public virtual Lookup Lookup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bulletin> Bulletins { get; set; }
    }
}
