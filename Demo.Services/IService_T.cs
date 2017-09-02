using System.Linq;

namespace Demo.Services {
  public interface IService<T> where T : class {
    IQueryable<T> Query();
    int SaveChanges();
  }
}
