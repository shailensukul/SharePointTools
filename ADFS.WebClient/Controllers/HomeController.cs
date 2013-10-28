using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADFS.WebClient.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Authenticate(string address, string username, string password, string wctx, string wtrealm, string wreply, string stsrole)
        {
            return null;
        }

    }
}
