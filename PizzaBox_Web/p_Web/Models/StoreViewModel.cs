using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace p_Web.Models
{
    public class StoreViewModel
    {
        [Display(Name = "Store Id")]
        public int StoreId { get; set; }
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }
        public string StoreCode { get; set; }

    }
}
