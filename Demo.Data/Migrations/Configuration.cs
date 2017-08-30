namespace Demo.Data.Migrations {
  using Demo.Models;
  using Demo.Models.Common;
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<Demo.Data.StoreDb> {
    public Configuration() {
      AutomaticMigrationsEnabled = false;
      ContextKey = "Demo.Data.StoreDb";
    }

    protected override void Seed(Demo.Data.StoreDb context) {

      var demo1 = new Store { Name = "Demo Store I" };
      demo1.Settings.Add(new StoreSetting {
        LanguageCode = "th",
        StoreDisplayName = "��ҹ������ҧ I",
        CompanyName = "����ѷ������ҧ I"
      });
      demo1.Settings.Add(new StoreSetting {
        LanguageCode = "em",
        StoreDisplayName = "Demo Store I",
        CompanyName = "Demo Company I"
      });

      var demo2 = new Store { Name = "Demo Store II" };
      demo2.Settings.Add(new StoreSetting {
        LanguageCode = "th",
        StoreDisplayName = "��ҹ������ҧ II",
        CompanyName = "����ѷ������ҧ II"
      });
      demo2.Settings.Add(new StoreSetting {
        LanguageCode = "em",
        StoreDisplayName = "Demo Store II",
        CompanyName = "Demo Company II"
      });

      context.Stores.AddOrUpdate(
        s => s.Name,
        demo1, demo2);

      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data. E.g.
      //
      //    context.People.AddOrUpdate(
      //      p => p.FullName,
      //      new Person { FullName = "Andrew Peters" },
      //      new Person { FullName = "Brice Lambson" },
      //      new Person { FullName = "Rowan Miller" }
      //    );
      //
    }
  }
}
