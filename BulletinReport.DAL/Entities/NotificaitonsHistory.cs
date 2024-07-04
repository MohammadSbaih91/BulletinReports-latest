namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NotificaitonsHistory")]
    public partial class NotificaitonsHistory
    {
        [Key]
        public int NotificationHistoryID { get; set; }

        public int NotificationTempleteID { get; set; }

        [StringLength(15)]
        public string MobileNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public string NotificationText { get; set; }

        public int StatusCode { get; set; }

        public DateTime SentDate { get; set; }

        [Required]
        [StringLength(20)]
        public string SendingResult { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(30)]
        public string CreatedBy { get; set; }

        public virtual Lookup Lookup { get; set; }

        public virtual Notification Notification { get; set; }
    }
}
