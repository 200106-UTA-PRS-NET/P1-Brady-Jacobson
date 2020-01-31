using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using p_Web.Models;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace p_Web.Controllers
{
    public class PlaceToppingsController : Controller
    {
        private readonly IRepository<Toppings> _repoToppings;
        public PlaceToppingsController(IRepository<Toppings> repo)
        {
            _repoToppings = repo;
        }

        [Route("PlaceToppings")]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddToppingsa()
        {
            Toppings newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Mozzarella Cheese"
            };
            var realTopping = _repoToppings.Addp(newT);

            newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Marinara Sauce"
            };
            realTopping = _repoToppings.Addp(newT);
            newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Mango"
            };
            realTopping = _repoToppings.Addp(newT);
            return View("/Views/Ordering/Choice.cshtml");
        }

        public IActionResult AddToppingsb()
        {
            Toppings newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Cheddar Cheese"
            };
            var realTopping = _repoToppings.Addp(newT);

            newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "BBQ Sauce"
            };
            realTopping = _repoToppings.Addp(newT);
            newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Bacon"
            };
            realTopping = _repoToppings.Addp(newT);
            newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Sausage"
            };
            realTopping = _repoToppings.Addp(newT);
            return View("/Views/Ordering/Choice.cshtml");
        }

        public IActionResult AddToppingsc()
        {
            Toppings newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Olive"
            };
            var realTopping = _repoToppings.Addp(newT);

            newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Mozzarella Cheese"
            };
            realTopping = _repoToppings.Addp(newT);
            newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Meat Sauce"
            };
            realTopping = _repoToppings.Addp(newT);
            return View("/Views/Ordering/Choice.cshtml");
        }

        public IActionResult AddToppingsh()
        {
            Toppings newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Cheddar Cheese"
            };
            var realTopping = _repoToppings.Addp(newT);

            newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Marinara Sauce"
            };
            realTopping = _repoToppings.Addp(newT);
            newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Pineapple"
            };
            realTopping = _repoToppings.Addp(newT);
            return View("/Views/Ordering/Choice.cshtml");
        }

        public IActionResult AddToppingsi()
        {
            Toppings newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Cheddar Cheese"
            };
            var realTopping = _repoToppings.Addp(newT);

            newT = new Toppings()
            {
                PizzaId = Convert.ToInt32(TempData.Peek("CurrentPizza")),
                Topping = "Mozzarella Cheese"
            };
            realTopping = _repoToppings.Addp(newT);

            return View("/Views/Ordering/Choice.cshtml");
        }
    }
}