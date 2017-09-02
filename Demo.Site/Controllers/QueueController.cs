using Demo.Data;
using Demo.Services.Queuing;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Site.Controllers {
  public class QueueController : Controller {

    private QueueService service;

    public QueueController() {
      var repo = new ServiceRepository();
      service = new QueueService(repo);
    }

    public ActionResult Index() {
      var services = service.GetServices();
      return View(services);
    }

    [HttpPost]
    public ActionResult GetTicket(int id) {
      var s = service.Find(id);
      var t = service.CreateTicket(s);

      var r = new ViewAsPdf("Ticket", t);
      r.PageSize = Rotativa.Options.Size.A7;
      r.PageOrientation = Rotativa.Options.Orientation.Portrait;

      var bytes = r.BuildPdf(ControllerContext);
      var path = Server.MapPath($"~/App_Data/{t.TicketNo}.pdf");
      System.IO.File.WriteAllBytes(path, bytes);

      return RedirectToAction("Index");
    }
  }
}