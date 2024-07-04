using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace BulletinReports.Attributes
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        private const string DefaultLanguage = "ar";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var lang = (string)filterContext.RouteData.Values["lang"] ?? DefaultLanguage;

            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang) { DateTimeFormat = { Calendar = new GregorianCalendar() } };
        }
    }
}