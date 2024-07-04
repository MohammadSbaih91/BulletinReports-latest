using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BulletinReport.DAL.Entities
{
    public partial class BulletinsDatabase : DbContext
    {
        public BulletinsDatabase()
            : base("name=BulletinsDatabase")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BlockedIP> BlockedIPs { get; set; }
        public virtual DbSet<Bulletin> Bulletins { get; set; }
        public virtual DbSet<Culture> Cultures { get; set; }
        public virtual DbSet<Department_Type> Department_Type { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<LookupCategory> LookupCategories { get; set; }
        public virtual DbSet<LookupCategoryCulture> LookupCategoryCultures { get; set; }
        public virtual DbSet<LookupCulture> LookupCultures { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
        public virtual DbSet<LookupsMapping> LookupsMappings { get; set; }
        public virtual DbSet<NotificaitonsHistory> NotificaitonsHistories { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<PoliceOffice> PoliceOffices { get; set; }
        public virtual DbSet<PoliceOfficesGroup> PoliceOfficesGroups { get; set; }
        public virtual DbSet<Procedure> Procedures { get; set; }
        public virtual DbSet<ProsecutorDuty> ProsecutorDuties { get; set; }
        public virtual DbSet<UserDepartment> UserDepartments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.FirstNameEn)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.LastNameEn)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.QatariId)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<BlockedIP>()
                .Property(e => e.IPAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Bulletin>()
                .HasMany(e => e.Procedures)
                .WithRequired(e => e.Bulletin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bulletin>()
                .HasMany(e => e.ProsecutorDuties)
                .WithMany(e => e.Bulletins)
                .Map(m => m.ToTable("BulletinProsecuterDuties").MapLeftKey("BulletinId").MapRightKey("ProsecutorId"));

            modelBuilder.Entity<Culture>()
                .Property(e => e.CultureName)
                .IsUnicode(false);

            modelBuilder.Entity<Culture>()
                .HasMany(e => e.LookupCultures)
                .WithRequired(e => e.Culture)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.CaseSerial)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Department>()
                .Property(e => e.BulletinSerial)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LookupCategory>()
                .Property(e => e.FixedCode)
                .IsUnicode(false);

            modelBuilder.Entity<LookupCategory>()
                .HasMany(e => e.LookupCategories1)
                .WithOptional(e => e.LookupCategory1)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<LookupCategory>()
                .HasMany(e => e.Lookups)
                .WithRequired(e => e.LookupCategory)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Lookup>()
                .Property(e => e.LookupCode)
                .IsUnicode(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Bulletins)
                .WithRequired(e => e.Lookup)
                .HasForeignKey(e => e.BulletinType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Bulletins1)
                .WithRequired(e => e.Lookup1)
                .HasForeignKey(e => e.OfficerRank)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Lookups1)
                .WithOptional(e => e.Lookup1)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.NotificaitonsHistories)
                .WithRequired(e => e.Lookup)
                .HasForeignKey(e => e.StatusCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.Lookup)
                .HasForeignKey(e => e.NotificationTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Notifications1)
                .WithRequired(e => e.Lookup1)
                .HasForeignKey(e => e.NotificationEventID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Procedures)
                .WithRequired(e => e.Lookup)
                .HasForeignKey(e => e.PublicProsecution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.ProsecutorDuties)
                .WithRequired(e => e.Lookup)
                .HasForeignKey(e => e.ProsecutorShiftTime)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NotificaitonsHistory>()
                .Property(e => e.MobileNumber)
                .IsUnicode(false);

            modelBuilder.Entity<NotificaitonsHistory>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NotificaitonsHistory>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.NotificationTextEn)
                .IsUnicode(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.NotificationCode)
                .IsUnicode(false);

            modelBuilder.Entity<Notification>()
                .HasMany(e => e.NotificaitonsHistories)
                .WithRequired(e => e.Notification)
                .HasForeignKey(e => e.NotificationTempleteID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.EmpCode)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserDepartments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
