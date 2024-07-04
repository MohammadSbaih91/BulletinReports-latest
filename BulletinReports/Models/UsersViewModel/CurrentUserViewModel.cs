using static BulletinReport.Common.Enums;

namespace BulletinReports.Models.UsersViewModel
{
    public class CurrentUserViewModel
    {
        public string FullName { get; set; }

        public string ProfileImagePath { get; set; }

        public UserType UserType { get; set; }

        public string WorkspaceLayout { get; set; }
        public string WorkspaceControllerName { get; set; }
    }
}