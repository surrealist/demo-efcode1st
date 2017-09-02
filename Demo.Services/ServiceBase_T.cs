using Demo.Data;
using System;
using System.Linq;

namespace Demo.Services {
  public class ServiceBase<T> : IService<T> where T : class {
    private readonly IRepository<T> repo;

    public ServiceBase(IRepository<T> repo) {
      this.repo = repo;
    }

    public IQueryable<T> Query() {
      return repo.Query();
    }

    public int SaveChanges() {
      return repo.SaveChanges();
    }
  }
}
