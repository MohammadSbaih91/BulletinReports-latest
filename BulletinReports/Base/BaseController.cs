using BulletinReport.Common.Helper;

using BulletinReports.Models.UsersViewModel;
using BulletinReports.UIHelper;

using Microsoft.AspNet.Identity;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

using static BulletinReport.Common.Enums;

namespace BulletinReports.Base
{

    public abstract class BaseController : Controller
    {
        protected readonly Guid CorrelationId = Guid.NewGuid();
        protected string GetCurrentUserEmail()
        {
            return User.Identity.Name; // Assuming the email is the username
        }
        protected string GetCurrentUser()
        {
            return User.Identity.Name;
        }
        protected string GetCurrentUserName()
        {
            if (Session["UserName"] != null && !string.IsNullOrWhiteSpace(Session["UserName"].ToString()))
            {
                return Session["UserName"].ToString();
            }
            else
            {
                return "Current_Username";
            }

            //return User.Identity.Name;
        }
        protected string CurrentUserName
        {
            get
            {
                if (Session["UserName"] != null && !string.IsNullOrWhiteSpace(Session["UserName"].ToString()))
                {
                    return Session["UserName"].ToString();
                }
                else
                {
                    return "Current_Username";
                }
                //return User.Identity.Name.Trim().ToLower();
                //var claims = HttpContext.Request.GetOwinContext().Authentication.User.Claims;
                //return claims.Where(x => x.Type == CyberResilience.Common.Constants.Claims.UserName).Single().Value;
            }
        }
        protected string CurrentAspNetId
        {
            get
            {
                return User.Identity.GetUserId().Trim().ToLower();
                //var claims = HttpContext.Request.GetOwinContext().Authentication.User.Claims;
                //return claims.Where(x => x.Type == CyberResilience.Common.Constants.Claims.UserName).Single().Value;
            }
        }
        /// <summary>
        /// Gets user ID
        /// </summary>
        protected int CurrentID
        {
            get
            {
                var claims = HttpContext.Request.GetOwinContext().Authentication.User.Claims;
                return int.Parse(claims.Where(x => x.Type == BulletinReport.Common.Constants.Claims.ID).Single().Value);

            }
        }
        //protected string CurrentAspNetID
        //{
        //    get
        //    {
        //        if (User == null || User.Identity == null)
        //        {
        //            return null;
        //        }

        //        var claims = HttpContext.Request.GetOwinContext().Authentication.User.Claims;
        //        return claims.Where(x => x.Type == Claims.AspNetID).Single().Value;

        //    }
        //}
        protected Culture CurrentCulture
        {
            get
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.Contains(BulletinReport.Common.Constants.Languages.Arabic.ToLower()))
                {
                    return BulletinReport.Common.Enums.Culture.Arabic;
                }

                return BulletinReport.Common.Enums.Culture.English;
            }
        }

        protected string GetCurrentUserPhoneNumber()
        {

            {
                return "0000000";
            }
        }

        protected string CurrentUserEmail
        {
            get
            {
                var claims = HttpContext.Request.GetOwinContext().Authentication.User.Claims;
                return claims.Where(x => x.Type == BulletinReport.Common.Constants.Claims.Email).Single().Value;
            }
        }
        public string UserMacAddress
        {
            get
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                String sMacAddress = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                }
                return sMacAddress;
            }
        }
        private SessionDataManager _sessionDataManager;
        public SessionDataManager SessionDataManager { get { return this._sessionDataManager; } }
        private ServiceRequestInformationDataManager _serviceRequestInformationDataManager;
        private CurrentUserrSessionDataManager _currentUserrSessionDataManager;
        private TempDataManager _tempDataManager;

        public TempDataManager TempDataManager { get { return this._tempDataManager; } }

        public int DefaultPageSize { get; private set; }

        public bool IsArabic { get { return LanguageSettingsHelper.IsArabic; } }

        public bool IsFrontend { get { return AppSettings.IsFrontEnd; } }

        public bool IsAnonymousUser
        {
            get
            {
                return !User.Identity.IsAuthenticated ||
                       User.Identity.Name.Trim().ToLower() ==
                       AppSettings.AnonymousUserInformation.Username.Trim().ToLower();
            }
        }

        public CurrentUserViewModel CurrentUserInformation { get { return _currentUserrSessionDataManager.GetCurrentUser(User.Identity.Name); } }

        protected List<IDisposable> ObjectsToCleanUp { get; set; }

        protected BaseController()
        {
            //_filelogger = new FileLogger(AppSettings.LogFilePath);
            //DefaultPageSize = IsFrontend ? FrontendSettings.DefaultPageSize : BackendSettings.DefaultPageSize;
            //_complaintComponent = new ComplaintComponent();

            //ObjectsToCleanUp = new List<IDisposable>();
        }

        protected string GenerateSmsCode()
        {
            var code = DateTime.Now.TimeOfDay.TotalMilliseconds.ToString();
            code = code.Replace(".", "");

            return code.Substring(code.Length - 4, 4);
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            LanguageSettingsHelper.SetCulture(RouteData);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //if (AppSettings.LogValidationErrors)
            //{
            //filterContext.Controller.ViewData.ModelState
            //}
            base.OnActionExecuted(filterContext);
            var loginMethod = Session["LoginMethod"] as string;
            if (loginMethod != null)
            {
                // You now know which method was used, you can adjust behavior accordingly
                ViewBag.LoginMethod = loginMethod;
                if (Session["UserName"] != null)
                {
                    ViewBag.UserName = Session["UserName"].ToString();
                }
            }

            if (ObjectsToCleanUp != null)
            {
                foreach (var disposableObject in ObjectsToCleanUp)
                {
                    if (disposableObject != null)
                    {
                        try
                        {
                            disposableObject.Dispose();
                        }
                        catch (Exception ex)
                        {
                            // nothing is needed here
                        }
                    }
                }
            }
            if (ConfigurationManager.AppSettings["IsLDAP"] != null)
            {
                bool isLdap = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLDAP"]);
                if (isLdap)
                {
                    if (Session["UserName"] == null)
                        FormsAuthentication.RedirectToLoginPage();
                }
            }
            //if (filterContext.HttpContext.Request.IsAjaxRequest())
            //    return;

            //var redirectResult = filterContext.Result as RedirectToRouteResult;
            //if (redirectResult == null)
            //    return;

            //var query = filterContext.HttpContext.Request.QueryString;

            //string key = "ReturnURL";
            //if (query.AllKeys.Contains(key))
            //{
            //    if (!redirectResult.RouteValues.ContainsKey("ReturnURL"))
            //        redirectResult.RouteValues.Add(key, query[key]);
            //    else
            //        redirectResult.RouteValues[key] = query[key];
            //}

        }

        protected override void OnException(ExceptionContext filterContext)
        {
            //if (AppSettings.DisableHandleWebExceptions)
            //{
            //    Tracer.Information($"{filterContext.Exception.Message}filterContext.Exception");
            //    base.OnException(filterContext);
            //}
            //else
            //{
            //    filterContext.ExceptionHandled = true;
            //    filterContext.Result =
            //        filterContext.HttpContext.Request.IsAjaxRequest()
            //        ? (ActionResult)Content(BulletinReport.Common.App_LocalResources.Resource.GenericError)
            //    //: (ActionResult)ReturnRedirectToGenericErrorPage(CyberResilience.Common.App_LocalResources.Resource.GenericError);
            //    : (ActionResult)RedirectToAction("Error", "Message");

            //    Tracer.Information($"{filterContext.Exception.Message}filterContext.Exception");

            //    base.OnException(filterContext);


            //    // handle k2 exception - user trying to access a task they has no permission to.
            //    if (filterContext.Exception.Message.StartsWith("24411 "))
            //    {
            //        filterContext.Result =
            //            filterContext.HttpContext.Request.IsAjaxRequest()
            //                ? (ActionResult)Content(BulletinReport.Common.App_LocalResources.Resource.YouAreNotAllowedToOpenThisTask)
            //     //: (ActionResult)ReturnRedirectToGenericErrorPage(CyberResilience.Common.App_LocalResources.Resource.YouAreNotAllowedToOpenThisTask);
            //     : (ActionResult)RedirectToAction("Error", "Message");
            //    }


            //    //_logger.Log(string.Format("filterContext.ExceptionHandled\n{0}\n",
            //    //    filterContext.ExceptionHandled));
            //    Tracer.Information(string.Format("filterContext.Exception.ToString()\n {0}",
            //        filterContext.Exception.ToString()));

            //    if (filterContext.Exception is System.Data.Entity.Validation.DbEntityValidationException)
            //    {
            //        var e = filterContext.Exception as System.Data.Entity.Validation.DbEntityValidationException;

            //        foreach (var eve in e.EntityValidationErrors)
            //        {
            //            Tracer.Information(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //                eve.Entry.Entity.GetType().Name, eve.Entry.State));
            //            foreach (var ve in eve.ValidationErrors)
            //            {
            //                Tracer.Information(string.Format("- Property: \"{0}\", Error: \"{1}\"",
            //                    ve.PropertyName, ve.ErrorMessage));
            //            }
            //        }
            //    }

            //    Tracer.Information(string.Format("filterContext.Controller.ControllerContext.RequestContext.HttpContext.Request.RawUrl\n{0}\n",
            //       filterContext.Controller.ControllerContext.RequestContext.HttpContext.Request.RawUrl));
            //}
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            //disable caching
            if (filterContext.IsChildAction)
                return;

            var cache = filterContext.HttpContext.Response.Cache;
            cache.AppendCacheExtension("private");
            cache.SetNoStore();
            cache.SetCacheability(HttpCacheability.NoCache);
            //cache.AppendCacheExtension("no-cache=Set-Cookie");
            cache.AppendCacheExtension("max-age=0");
            cache.AppendCacheExtension("post-check=0");
            cache.AppendCacheExtension("pre-check=0");
            cache.SetProxyMaxAge(TimeSpan.Zero);
            cache.SetExpires(DateTime.Now.AddYears(-5));
            cache.SetValidUntilExpires(false);
            cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        }

        protected void Delay(int milliseconds = 2000)// 2 seconds.
        {
            System.Threading.Thread.Sleep(milliseconds);
        }
    }
}
