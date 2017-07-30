using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models.Settings {
    public class StoreSettingCollection : HashSet<StoreSetting> { 

        public StoreSetting this[string languageCode]
            => this.SingleOrDefault(x => x.LanguageCode == languageCode);

    }
}
