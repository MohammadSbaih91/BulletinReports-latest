namespace BulletinReport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserDepartment
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int DepartmentID { get; set; }

        public bool IsSelected { get; set; }

        public virtual User User { get; set; }
    }
}
