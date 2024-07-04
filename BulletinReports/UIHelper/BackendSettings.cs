namespace BulletinReports.UIHelper
{
    public static class BackendSettings
    {
        public static int DefaultPageSize
        {
            get { return 10; }
        }

        public static string MasterLayout { get { return @"~/Views/Shared/_Layout.cshtml"; } }
        public static string LayoutManagement { get { return @"~/Views/Shared/_LayoutManagement.cshtml"; } }
        public static string WorkspaceLayout { get { return @"~/Views/Shared/_WorkspaceLayout.cshtml"; } }
        public static string AccreditationOrQulificationLayout { get { return @"~/Views/Shared/_AccreditationOrQulificationLayout.cshtml"; } }
        public static string CallCenterWorkspaceLayout { get { return @"~/Views/Shared/_CallCenterWorkspaceLayout.cshtml"; } }

        public static string WorkspaceWithoutStatisticsLayout { get { return @"~/Views/Shared/_WorkspaceWithoutStatisticsLayout.cshtml"; } }
        public static string WorkspacePlainLayout { get { return @"~/Views/Shared/_PlainLayout.cshtml"; } }

        public static string SuperAdminLayout { get { return @"~/Views/Shared/_SuperAdminLayout.cshtml"; } }

        public static string RevenueEmployeesLayout { get { return @"~/Views/Shared/_RevenueEmployees.cshtml"; } }

        public static class WorkSpaceControllerName
        {
            public static string SuperAdminController { get { return @"SuperAdmin"; } }

            public static string CallCenterEmployeeController { get { return @"CallCenterEmployee"; } }
            public static string CallCenterSupervisorController { get { return @"CallCenterSupervisor"; } }
            public static string CCHICallCenterSupervisorController { get { return @"CCHICallCenterSupervisor"; } }
            public static string CCHIDepartmentManagersController { get { return @"CCHIDepartmentManagers"; } }
            public static string CCHISectionManagerController { get { return @"CCHISectionManager"; } }
            public static string CustomerServiceEmployeeController { get { return @"CustomerServiceEmployee"; } }
            public static string AccreditationOrQulificationEmployeeController { get { return @"AccreditationOrQulificationEmployee"; } }
            public static string RevenuesWorkspaceController { get { return @"RevenuesWorkspace"; } }
        }


    }
}