using System.Linq;

namespace Demo.Data {
  public abstract class RepositoryBase<T> : IRepository<T> where T : class {

    private StoreDb db = new StoreDb();

    public IQueryable<T> Query() {
      return db.Set<T>().AsQueryable();
    }

    public int SaveChanges() {
      return db.SaveChanges();
    }

  }
}
