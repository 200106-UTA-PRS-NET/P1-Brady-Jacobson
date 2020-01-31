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
    public class PlacePizzaController : Controller
    {
        private readonly IRepository<Pizzas> _repoPizzas;
        public PlacePizzaController(IRepository<Pizzas> repo)
        {
            _repoPizzas = repo;
        }

        [Route("PlacePizza")]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PreviewPizzas()
        {
            string temp = TempData.Peek("CurrentOrder").ToString();
            var allPizzas = _repoPizzas.Getp(temp);
            List<PizzaViewModel> pVM = new List<PizzaViewModel>();
            foreach (var item in allPizzas)
            {
                PizzaViewModel s = new PizzaViewModel();
                s.Crust = item.Crust;
                s.Size = item.Size;
                s.PizzaCost = item.PizzaCost;
                pVM.Add(s);
            }
            return View("/Views/Ordering/Preview.cshtml", pVM);
        }
        public IActionResult AddtoOrderH()
        {
            Pizzas a = new Pizzas()
            {
                OrderId = Convert.ToInt32(TempData.Peek("CurrentOrder")),
                Crust = "Original",
                Size = "8",
                PizzaCost = 6.00m
            };
            var realPizza = _repoPizzas.Addp(a);
            TempData["CurrentPizza"] = realPizza.PizzaId;

            int result = Convert.ToInt32(TempData.Peek("PizzaAmount"));
            TempData["PizzaAmount"] = result + 1;
            return RedirectToAction("AddToppingsh", "PlaceToppings");
        }
        public IActionResult AddtoOrderB()
        {
            Pizzas a = new Pizzas()
            {
                OrderId = Convert.ToInt32(TempData.Peek("CurrentOrder")),
                Crust = "Stuffed",
                Size = "16",
                PizzaCost = 9.549m
            };
            var realPizza = _repoPizzas.Addp(a);
            TempData["CurrentPizza"] = realPizza.PizzaId;

            int result = Convert.ToInt32(TempData.Peek("PizzaAmount"));
            TempData["PizzaAmount"] = result + 1;
            return RedirectToAction("AddToppingsb", "PlaceToppings");
        }
        public IActionResult AddtoOrderA()
        {
            Pizzas a = new Pizzas()
            {
                OrderId = Convert.ToInt32(TempData.Peek("CurrentOrder")),
                Crust = "Original",
                Size = "12",
                PizzaCost = 7.00m
            };
            var realPizza = _repoPizzas.Addp(a);
            TempData["CurrentPizza"] = realPizza.PizzaId;

            int result = Convert.ToInt32(TempData.Peek("PizzaAmount"));
            TempData["PizzaAmount"] = (result + 1).ToString();
            return RedirectToAction("AddToppingsa", "PlaceToppings");
        }
        public IActionResult AddtoOrderI()
        {
            Pizzas a = new Pizzas()
            {
                OrderId = Convert.ToInt32(TempData.Peek("CurrentOrder")),
                Crust = "Thin crust",
                Size = "8",
                PizzaCost = 7.50m
            };
            var realPizza = _repoPizzas.Addp(a);
            TempData["CurrentPizza"] = realPizza.PizzaId;

            int result = Convert.ToInt32(TempData.Peek("PizzaAmount"));
            TempData["PizzaAmount"] = result + 1;
            return RedirectToAction("AddToppingsi", "PlaceToppings");
        }
        public IActionResult AddtoOrderC()
        {
            Pizzas a = new Pizzas()
            {
                OrderId = Convert.ToInt32(TempData.Peek("CurrentOrder")),
                Crust = "Stuffed",
                Size = "8",
                PizzaCost = 7.50m
            };
            var realPizza = _repoPizzas.Addp(a);
            TempData["CurrentPizza"] = realPizza.PizzaId;

            int result = Convert.ToInt32(TempData.Peek("PizzaAmount"));
            TempData["PizzaAmount"] = result + 1;
            return RedirectToAction("AddToppingsc", "PlaceToppings");
        }
        public IActionResult Done()
        {
            var allPizzas = _repoPizzas.Getp(Convert.ToInt32(TempData.Peek("CurrentOrder")).ToString());
            Decimal total = 0;
            foreach(var item in allPizzas)
            {
                total = total + item.PizzaCost;
            }
            string tempstorage = total.ToString();
            TempData["DecimalValue"] = tempstorage;
            return RedirectToAction("Done", "PlaceOrder");
        }
    }
}