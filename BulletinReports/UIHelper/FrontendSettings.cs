namespace BulletinReports.UIHelper
{
    public static class FrontendSettings
    {
        public static int DefaultPageSize { get { return 10; } }
        public static string AdminWorkspace { get { return @"~/Views/Shared/_AdminLayout.cshtml"; } }
        public static string MasterLayout { get { return @"~/Views/Shared/_Layout.cshtml"; } }

        public static string PublicFacingLayout { get { return @"~/Views/Shared/_PublicFacingLayout.cshtml"; } }

        public static string LoginLayout { get { return @"~/Views/Shared/Layouts/_LoginLayout.cshtml"; } }
        public static string SecondPartyRepresentativeWorkspaceLayoutWithoutSearch { get { return @"~/Views/Shared/_RepresentativeSecondPartyLayout_WithoutSearch.cshtml"; } }
        // === Workspace layouts
        public static string SecondPartyRepresentativeWorkspaceLayout { get { return @"~/Views/Shared/_RepresentativeSecondPartyLayout.cshtml"; } }
        public static string SecondPartyAutoRepWorkspaceLayout { get { return @"~/Views/Shared/_SecondPartyAutoRepLayout.cshtml"; } }
        public static string SecondPartyOwnerWorkspaceLayout { get { return @"~/Views/Shared/_OwnerSecondPartyLayout.cshtml"; } }
        public static string ConsultantLayout { get { return @"~/Views/Shared/_ConsultantLayout.cshtml"; } }
        public static string OperatorLayout { get { return @"~/Views/Shared/_OperatorLayout.cshtml"; } }
        public static string RegisteredUserWorkspaceLayout { get { return @"~/Views/Shared/_RegisteredUserWorkspaceLayout.cshtml"; } }
        public static string SecondPartyCustomerServiceWorkspaceLayout { get { return @"~/Views/Shared/_SecondPartyCustomerServiceWorkspaceLayout.cshtml"; } }
        public static string SecondPartyCustomerServiceManagerWorkspaceLayout { get { return @"~/Views/Shared/_SecondPartyCustomerServiceManagerWorkspaceLayout.cshtml"; } }
        public const string TempRepresentativeSecondPartyLayout = @"~/Views/Shared/_TempRepresentativeSecondPartyLayout.cshtml";
        public static string SurveyLayout { get { return @"~/Views/Shared/_SurveyLayout.cshtml"; } }
    }
}