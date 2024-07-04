namespace BulletinReport.Common
{
    public class Enums
    {
        public enum CommunicationType
        {
            EMail = 6,
            SMS = 5
        }
        public enum CultureID
        {
            Ar = 1,
            En = 2,
        }

        public enum Culture
        {
            Arabic = 9,
            English = 10
        }
        public enum UserType
        {
            Administrator = 2,
            Authority = 3,
            Registerd = 1,
            Anonymous = 5
        }
        public enum ApplicationTypes
        {
            FrontendApp = 1,
            BackendApp = 2,
            MobileApllication = 3,
            Morasalat = 4
        }
        public enum UserRole
        {
            RegisteredUser = 1,
            Admin = 2,
            Employee = 3,
            AnonymousUser = 4,
        }
        public enum UserStatus
        {
            ActiveUser = 3,
            StoppedUser = 4,
            RegistredUser = 5,
            DeletedUser = 6,
        }
    }
}
