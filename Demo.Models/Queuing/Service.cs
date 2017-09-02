using System;
using System.Collections.Generic;

namespace Demo.Models.Queuing {
  public class Service {

    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public int NextTicketId { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Ticket> Tickets { get; set; }

    public Ticket CreateAndEnqueueTicket() {
      DateTime dt = DateTime.Now;

      if (dt.Minute % 2 == 1) {
        throw new Exception("Cannot create a new ticket on odd minute!");
      }

      var t = new Ticket();

      t.Id = NextTicketId++;
      t.Date = dt;
      Tickets.Add(t);

      return t;
    }

  }
}
