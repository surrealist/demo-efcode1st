using Demo.Models.Queuing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Data;

namespace Demo.Services.Queuing {
  public class QueueService : ServiceBase<Service> {

    public QueueService(IRepository<Service> repo) 
      : base(repo) {
      //
    }

    public Service Find(int id) {
      return Query().SingleOrDefault(s => s.Id == id);
    }

    public IEnumerable<Service> GetServices() {
      return Query().Where(s => s.IsActive).ToList();
    }

    public Ticket CreateTicket(Service s) {
      var t = s.CreateAndEnqueueTicket();
      SaveChanges();

      return t;
    }

  }
}
