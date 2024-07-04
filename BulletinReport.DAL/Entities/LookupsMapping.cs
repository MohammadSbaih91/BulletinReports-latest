namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LookupsMapping")]
    public partial class LookupsMapping
    {
        public int Id { get; set; }

        public int? BusinessObjectTypeId { get; set; }

        public int? LookupId { get; set; }

        public int? MappingTypeId { get; set; }

        public virtual Lookup Lookup { get; set; }
    }
}
