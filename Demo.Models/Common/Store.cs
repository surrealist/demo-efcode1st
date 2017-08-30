using Demo.Models.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models.Common {
  public class Store {

    public Store() {
      IsActive = true;
      IsDeleted = false;
      Settings = new StoreSettingCollection();
    }
     
    //
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    public bool IsActive { get; private set; } 
    public bool IsDeleted { get; set; } 

    [StringLength(1024)]
    public string Remark { get; set; }

    public virtual StoreSettingCollection Settings { get; set; } 


    // 
    public void Inactivate() {
      if (DateTime.Now.TimeOfDay.TotalHours < 12.0) {
        throw new Exception("You must inactive store before noon!");
      }

      IsActive = false;
    }

    public void Activate() {
      if (IsActive) throw new Exception("It was already active. You cannot reactivate this store.");

      IsActive = true;
    }
  }
}
