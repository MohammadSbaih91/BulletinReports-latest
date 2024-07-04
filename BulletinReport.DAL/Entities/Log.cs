namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Log
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string MessageTemplate { get; set; }

        [StringLength(128)]
        public string Level { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Exception { get; set; }

        public string Properties { get; set; }

        public string User { get; set; }

        public string IPAddress { get; set; }

        public string Channel { get; set; }
    }
}
