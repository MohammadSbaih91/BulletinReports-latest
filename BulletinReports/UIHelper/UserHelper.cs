using BulletinReport.BLL.UsersBusinessLogic;
using BulletinReport.Common.Helper;

using BulletinReports.Models.UsersViewModel;

using System.Collections.Generic;
using System.Linq;

using static BulletinReport.Common.Constants;
using static BulletinReport.Common.Enums;

namespace BulletinReports.UIHelper
{
    public class UserHelper
    {
        public static UserType GetUserType(List<string> roles)
        {
            var userType = UserType.Anonymous;

            var rolesLowered =
                roles.Select(x => x.Trim().ToLower())
                .ToList();

            if (AppSettings.IsFrontEnd)
            {
                if (rolesLowered.Contains(UserRoles.Admin.ToLower()))
                    userType = UserType.Administrator;
                else if (rolesLowered.Contains(UserRoles.RegisteredUser.ToLower()))
                    userType = UserType.Registerd;

                else if (rolesLowered.Contains(UserRoles.AnonymousUser.ToLower()))
                    userType = UserType.Anonymous;
            }
            else
            {
                if (rolesLowered.Contains(UserRoles.Admin.ToLower()))
                    userType = UserType.Administrator;

                //else if (rolesLowered.Contains(UserRoles.Backend.CCHIDepartmentManger.ToLower()))
                //    userType = UserType.CchiDepartmentManager;


            }

            return userType;
        }

        public static CurrentUserViewModel GetUserInformation(string username)
        {
            AspNetUserBusinessLogic userComponent = new AspNetUserBusinessLogic();

            var userInformation = new CurrentUserViewModel
            {
                FullName = "Anonymous", // default name
            };

            //if (AppSettings.IsFrontEnd)
            //{
            //    var user = userComponent.GetUserByName(username);
            //    if (user != null)
            //    {
            //        userInformation.FullName = string.IsNullOrWhiteSpace(user.UserName) ? username : user.FullName;
            //        userInformation.ProfileImagePath = user.PersonalPhoto;
            //    }
            //}
            //userInformation.UserType = GetUserType(username);
            userInformation.WorkspaceLayout = GetWorkspaceLayout(userInformation.UserType);
            userInformation.WorkspaceControllerName = GetWorkspaceControllerName(userInformation.UserType);

            return userInformation;
        }

        private static string GetWorkspaceLayout(UserType userType)
        {
            string workspace = FrontendSettings.PublicFacingLayout;
            if (AppSettings.IsFrontEnd)
            {
                switch (userType)
                {
                    case UserType.Administrator:
                        workspace = FrontendSettings.AdminWorkspace;
                        break;
                    case UserType.Registerd:
                        workspace = FrontendSettings.RegisteredUserWorkspaceLayout;
                        break;

                    case UserType.Anonymous:
                        workspace = FrontendSettings.PublicFacingLayout;
                        break;

                }
            }
            else
            {
                workspace = BackendSettings.WorkspaceLayout;

                switch (userType)
                {
                    case UserType.Administrator:
                        workspace = BackendSettings.SuperAdminLayout;
                        break;
                    case UserType.Anonymous:
                        workspace = BackendSettings.WorkspacePlainLayout;
                        break;
                }
            }

            return workspace;
        }


        private static string GetWorkspaceControllerName(UserType userType)
        {
            string workspaceControllerName = string.Empty;
            if (!AppSettings.IsFrontEnd)
            {


                switch (userType)
                {
                    case UserType.Administrator:
                        workspaceControllerName = BackendSettings.WorkSpaceControllerName.SuperAdminController;
                        break;

                    case UserType.Anonymous:
                        workspaceControllerName = BackendSettings.WorkSpaceControllerName.CustomerServiceEmployeeController;
                        break;

                    case UserType.Registerd:
                        workspaceControllerName = BackendSettings.WorkSpaceControllerName.CallCenterEmployeeController;
                        break;
                }
            }

            return workspaceControllerName;
        }

        private static UserType GetUserType(string username)
        {

            AspNetRolesBusinessLogic userRoles = new AspNetRolesBusinessLogic();

            var roles =
                userRoles.GetRolesByUserName(username)
                .Select(x => x.TrimEnd().ToLower());

            var userType = GetUserType(roles.ToList());

            return userType;

        }
    }
}