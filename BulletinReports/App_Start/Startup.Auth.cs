using BulletinReports.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;

using Owin;

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BulletinReports
{

    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);

            CookieAuthenticationProvider provider = new CookieAuthenticationProvider();
            var originalHandler = provider.OnApplyRedirect;

            provider.OnApplyRedirect = context =>
            {
                var mvcContext = new HttpContextWrapper(HttpContext.Current);
                var routeData = RouteTable.Routes.GetRouteData(mvcContext);

                RouteValueDictionary routeValues = new RouteValueDictionary();
                routeValues.Add("lang", routeData.Values["lang"]);

                Uri uri = new Uri(context.RedirectUri);
                string returnUrl = HttpUtility.ParseQueryString(uri.Query)[context.Options.ReturnUrlParameter];
                routeValues.Add(context.Options.ReturnUrlParameter, returnUrl);

                context.RedirectUri = url.Action("login", "account", routeValues);
                originalHandler.Invoke(context);
            };

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }
    }
}