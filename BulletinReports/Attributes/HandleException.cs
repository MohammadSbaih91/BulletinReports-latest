using BulletinReport.Common.Utilities;

using System.Web.Mvc;

namespace BulletinReports.Attributes
{

    /// <summary>
    /// Serves as a filter to handle errors
    /// </summary>
    public class HandleException : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];

            Tracer.Error(filterContext.Exception);

            var result = new ViewResult()
            {
                //ViewName = "~/Views/Errors/index.cshtml"
            };

            result.TempData["Error"] = filterContext.Exception;

            filterContext.Result = result;
            filterContext.ExceptionHandled = true;
        }
    }
}