using System;

namespace Demo.Models.Queuing {
  public class Ticket {

    public int Id { get; set; }
    public DateTime Date { get; set; }

    public Service Service { get; set; }

    public string TicketNo => $"{Service.Code}-{Id:000}";
  }
}
