using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models.Queuing {
  public class Ticket {

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public Service Service { get; set; }

    public string TicketNo => $"{Service.Code}-{Id:000}";
  }
}
