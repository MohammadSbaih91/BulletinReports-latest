namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Notification()
        {
            NotificaitonsHistories = new HashSet<NotificaitonsHistory>();
        }

        public int NotificationID { get; set; }

        public int NotificationTypeID { get; set; }

        public int NotificationEventID { get; set; }

        [Required]
        public string NotificationTextAr { get; set; }

        [Required]
        public string NotificationTextEn { get; set; }

        [Required]
        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        [StringLength(50)]
        public string NotificationCode { get; set; }

        public virtual Lookup Lookup { get; set; }

        public virtual Lookup Lookup1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotificaitonsHistory> NotificaitonsHistories { get; set; }
    }
}
