using System;

namespace BulletinReport.Common.DTOs.LookupsDTO
{
    public class LookupsDTO
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int CategoryId { get; set; }
        public string LookupCode { get; set; }
        public int? LOrder { get; set; }
        public int? Sequence { get; set; }
        public bool? IsInternal { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDefault { get; set; }

        public string ValueAr { get; set; }
        public string ValueEn { get; set; }
        public string Value
        {
            get; set;
        }
        public DateTime CreatedOn { get; set; }
        public string Createdby { get; set; }
    }
}
