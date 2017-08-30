using Demo.Data;
using Demo.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Site.Controllers {
  public class HomeController : Controller {

    private StoreDb db = new StoreDb();

    protected override void Dispose(bool disposing) {
      if (disposing) {
        db.Dispose();
      }
      base.Dispose(disposing);
    }


    public ActionResult Index() {
      ViewBag.CountStore = db.Stores.Count();
       
      //var q = from s in db.Stores
      //        where !s.IsDeleted
      //        select s;
      //return View(q.ToList());

      return View(db.ActiveStores.ToList());
    }

    [HttpPost]
    public ActionResult InactivateStore(int id) {
      var s = db.Stores.Find(id);
      try {
        s.Inactivate();
        db.SaveChanges();
      }catch(Exception ex) {
        TempData["Error"] = ex.Message;
      }
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult ActivateStore(int id) {
      var s = db.Stores.Find(id);
      try {
        s.Activate();
        db.SaveChanges();
      }
      catch (Exception ex) {
        TempData["Error"] = ex.Message;
      }
      return RedirectToAction("Index");
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