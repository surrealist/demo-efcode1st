using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models {
    public class StoreSetting {

        public int Id { get; set; }

        [StringLength(5)]
        [Index]
        public string LanguageCode { get; set; }

        [StringLength(200)]
        public string ShopName { get; set; }

        [StringLength(200)]
        public string CompanyName { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }
         
    }
}
