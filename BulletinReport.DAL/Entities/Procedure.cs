namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Procedure
    {
        public int Id { get; set; }

        public int PublicProsecution { get; set; }

        public DateTime ProcedureTime { get; set; }

        [Required]
        [StringLength(128)]
        public string Prosecutor { get; set; }

        public bool? HasBeenMoved { get; set; }

        public bool? NotBeenMoved { get; set; }

        [Required]
        [StringLength(128)]
        public string ProcedureCreatedBy { get; set; }

        public DateTime ProcedureCreatedAt { get; set; }

        [StringLength(128)]
        public string ProcedureUpdatedBy { get; set; }

        public DateTime? ProcedureUpdatedAt { get; set; }

        [StringLength(128)]
        public string ProcedureDeletedBy { get; set; }

        public DateTime? ProcedureDeletedAt { get; set; }

        public string ProcedureNotes { get; set; }

        public int BulletinId { get; set; }

        public virtual Bulletin Bulletin { get; set; }

        public virtual Lookup Lookup { get; set; }
    }
}
