using Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Site.Controllers {
    public class HomeController : Controller {

        private StoreDb db = new StoreDb();

        protected override void Dispose(bool disposing) {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Index() {
            ViewBag.CountStore = db.Stores.Count();
            var s = db.Stores.Find(1);
            return View(s);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}