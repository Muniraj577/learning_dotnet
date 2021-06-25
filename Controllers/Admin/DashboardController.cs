using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers.Admin
{
    [RoutePrefix("admin")]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [Route("dashboard", Name = "dashboard")]
        public ActionResult Dashboard()
        {
            return View("~/Views/Admin/Dashboard.cshtml");
        }
    }
}