using BulletinReports.Attributes;

using System.Web.Mvc;

namespace BulletinReports
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleException());
            filters.Add(new LocalizationAttribute());
        }
    }
}
