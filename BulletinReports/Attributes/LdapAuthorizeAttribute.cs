using System.Web;
using System.Web.Mvc;

public class LdapAuthorizeAttribute : AuthorizeAttribute
{
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        // Check if the user is authenticated based on session data
        var isAuthenticated = httpContext.Session["UserName"] != null;
        return isAuthenticated;
    }

    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        // Redirect to login page if the user is not authorized
        filterContext.Result = new RedirectResult("~/Account/Login");
    }
}
