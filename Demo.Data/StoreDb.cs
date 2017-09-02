using Demo.Models.Common;
using Demo.Models.Queuing;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data {
  public class StoreDb : DbContext {

    public DbSet<Store> Stores { get; set; }

    public DbSet<Service> Services  { get; set; }
    public DbSet<Ticket> Tickets { get; set; } 

    public IQueryable<Store> ActiveStores =>
      Set<Store>().Where(s => !s.IsDeleted);
  }
}
