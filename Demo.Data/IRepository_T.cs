using System.Linq;

namespace Demo.Data {
  public interface IRepository<T> where T : class {

    IQueryable<T> Query();
    int SaveChanges();

  }
}
