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
            Settings = new StoreSettingCollection();
        }
        public int Id { get; set; }
        public virtual StoreSettingCollection Settings { get; set; }

        public bool IsActive { get; private set; } = true;
        public bool IsDeleted { get; set; } = false;

        // methods 
        public void Inactivate() {
            if (DateTime.Now.TimeOfDay.TotalHours < 12.0)
            {
                throw new Exception("You must inactive store before noon!");
            }

            IsActive = false;
        }
    }
}
