using BulletinReport.BLL.UsersBusinessLogic;

using BulletinReports.Models;
using BulletinReports.UIHelper;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using static BulletinReport.Common.Enums;

namespace BulletinReports.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private AspNetUserBusinessLogic _AspNetUsersBusinessLogic;
        private AspNetRolesBusinessLogic _AspNetRolesBusinessLogic;
        public AccountController()
        {
            _AspNetUsersBusinessLogic = new AspNetUserBusinessLogic();
            _AspNetRolesBusinessLogic = new AspNetRolesBusinessLogic();
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View("Login"); // Reuse the Login view or create a specific view for LDAP if necessary
        }
        //use this with real web login  method-->
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            //UserType usertype;
            var roles = UserManager.GetRoles(_AspNetUsersBusinessLogic.GetUserIdByUserName(model.UserName)).ToList();
            UserType userType = UserHelper.GetUserType(roles);

            switch (result)
            {
                case SignInStatus.Success:
                    if (userType == UserType.Administrator)
                    {
                        Session["LoginMethod"] = "Web";
                        return RedirectToAction("Index", "Bulletin");
                    }
                    return RedirectToAction("Index", "Bulletin");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
        //use this with real LDAP Active Directory and comment the upper login method-->
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginViewModel model, string returnUrl)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return View("Login", model);
        //    }

        //    string LdapPath = ConfigurationManager.AppSettings["LDAPPath"];
        //    bool isValid = false;
        //    string UserPhoneNumber = null;
        //    string UserName = null;
        //    string Token = null;

        //    try
        //    {
        //        using (var entry = new DirectoryEntry(LdapPath, model.UserName, model.Password))
        //        {
        //            var nativeObject = entry.NativeObject;
        //            Token = entry.NativeGuid;
        //            isValid = true;

        //            // Search for the user in the directory
        //            using (var searcher = new DirectorySearcher(entry))
        //            {
        //                searcher.Filter = $"(sAMAccountName={model.UserName})";
        //                searcher.PropertiesToLoad.Add("telephoneNumber"); // or "mobile", depending on your needs
        //                searcher.PropertiesToLoad.Add("sAMAccountName"); // Add this line to load the actual username

        //                var result = searcher.FindOne();
        //                if (result != null)
        //                {
        //                    UserName = result.Properties["sAMAccountName"]?.Count > 0 ? result.Properties["sAMAccountName"][0].ToString() : null;
        //                    Session["UserPhoneNumber"] = UserPhoneNumber;
        //                }
        //            }
        //        }

        //        if (isValid)
        //        {
        //            Session["LoginMethod"] = "LDAP";
        //            Session["UserName"] = UserName;

        //            FormsAuthentication.SetAuthCookie(UserName, false);
        //            HttpCookie AuthCookie = FormsAuthentication.GetAuthCookie(UserName, false);
        //            FormsAuthenticationTicket AuthTicket = FormsAuthentication.Decrypt(AuthCookie.Value);
        //            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(AuthTicket.Version, AuthTicket.Name, AuthTicket.IssueDate, AuthTicket.Expiration, AuthTicket.IsPersistent, Token);
        //            AuthCookie.Value = FormsAuthentication.Encrypt(Ticket);

        //            return RedirectToAction("Index", "Bulletin");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "LDAP login failed.");
        //            return View("Login", model);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions appropriately
        //        ModelState.AddModelError("", "حدث خطأ في النظام، يرجى الاتصال مدير النظام");
        //        return View("Login", model);
        //    }
        //}

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            HttpCookie cookie = new HttpCookie(".AspNet.ApplicationCookie", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie(".AspNet.ApplicationCookie", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            Session.Abandon();
            FormsAuthentication.RedirectToLoginPage();
            return null;
        }
        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}