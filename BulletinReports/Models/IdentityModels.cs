using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System.Security.Claims;
using System.Threading.Tasks;

namespace BulletinReports.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstNameAr { get; set; }
        public string FirstNameEn { get; set; }
        public string LastNameAr { get; set; }
        public string LastNameEn { get; set; }
        public string PassportId { get; set; }
        public string Mobile { get; set; }
        public string QatariId { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adding FirstName and LastName as claims:
            userIdentity.AddClaim(new Claim("FirstNameAr", this.FirstNameAr ?? ""));
            userIdentity.AddClaim(new Claim("FirstNameEn", this.FirstNameEn ?? ""));
            userIdentity.AddClaim(new Claim("LastNameAr", this.LastNameAr ?? ""));
            userIdentity.AddClaim(new Claim("LastNameEn", this.LastNameEn ?? ""));
            userIdentity.AddClaim(new Claim("PassportId", this.PassportId ?? ""));
            userIdentity.AddClaim(new Claim("Mobile", this.Mobile ?? ""));
            userIdentity.AddClaim(new Claim("QatariId", this.QatariId ?? ""));
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BulletinsDatabase", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}