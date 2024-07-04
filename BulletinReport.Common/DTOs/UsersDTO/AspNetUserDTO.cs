using System;

namespace BulletinReport.Common.DTOs
{
    public class AspNetUserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public string UserName { get; set; }
        public string FirstNameAr { get; set; }

        public string FirstNameEn { get; set; }

        public string LastNameAr { get; set; }

        public string LastNameEn { get; set; }


    }
}
