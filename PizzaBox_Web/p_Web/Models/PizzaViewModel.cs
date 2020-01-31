using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace p_Web.Models
{
    public class PizzaViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "Crust")]
        public string Crust { get; set; }
        [Display(Name = "Size")]
        public string Size { get; set; }
        [Display(Name = "Cost")]
        public Decimal PizzaCost { get; set; }
    }
}
