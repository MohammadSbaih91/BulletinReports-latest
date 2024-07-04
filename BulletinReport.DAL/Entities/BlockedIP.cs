namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BlockedIP
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string IPAddress { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }
    }
}
