using BulletinReports.Base;

using System.Web.Mvc;

namespace BulletinReports.Area.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}