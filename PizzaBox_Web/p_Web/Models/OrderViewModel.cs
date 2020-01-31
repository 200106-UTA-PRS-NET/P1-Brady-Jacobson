using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace p_Web.Models
{
    public class OrderViewModel
    {
        [Display(Name = "Store ID")]
        public int StoreID { get; set;}
        [Display(Name = "Pizza Amount")]
        public int PizzaAmount{ get; set; }
        [Display(Name = "Pizza Cost")]
        public Decimal Cost { get; set; }
        [Display(Name = "Time ordered")]
        public DateTime OrderedTime{ get; set; }
    }
}
