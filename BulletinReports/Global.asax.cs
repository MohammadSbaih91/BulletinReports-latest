using Aspose.Pdf;

using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
namespace BulletinReports
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Initialize Aspose.PDF license
            InitializeAsposePdfLicense();
        }

        private void InitializeAsposePdfLicense()
        {
            License license = new License();

            // Assume your license file is in the App_Data folder
            string licenseFile = Server.MapPath("~/App_Data/Aspose.Pdf.lic");
            license.SetLicense(licenseFile);
        }

    }
}
