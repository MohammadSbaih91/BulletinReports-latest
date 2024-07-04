using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GCAP.DAL.Entities
{
    public partial class GCAP : DbContext
    {
        public GCAP()
            : base("name=GCAP")
        {
        }

        public virtual DbSet<CodingTable> CodingTables { get; set; }
        public virtual DbSet<CodingTablesData> CodingTablesDatas { get; set; }
        public virtual DbSet<Department_Type> Department_Type { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<PoliceOffice> PoliceOffices { get; set; }
        public virtual DbSet<PoliceOfficesGroup> PoliceOfficesGroups { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodingTable>()
                .HasMany(e => e.CodingTablesDatas)
                .WithRequired(e => e.CodingTable)
                .HasForeignKey(e => e.CodeTableID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department_Type>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.CaseSerial)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Department>()
                .Property(e => e.BulletinSerial)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Department1)
                .HasForeignKey(e => e.Department);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.PoliceOffices)
                .WithMany(e => e.Departments)
                .Map(m => m.ToTable("DepartmentPoliceOffices").MapLeftKey("DepartmentID").MapRightKey("PoliceOfficeID"));

            modelBuilder.Entity<User>()
                .Property(e => e.EmpCode)
                .HasPrecision(18, 0);
        }
    }
}
