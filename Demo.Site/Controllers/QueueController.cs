using Demo.Data;
using Demo.Services.Queuing;
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
  }
}