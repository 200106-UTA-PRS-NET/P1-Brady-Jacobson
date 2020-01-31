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
    public class PlaceOrderController : Controller
    {
        private readonly IRepository<Orders> _repoOrders;
        public PlaceOrderController(IRepository<Orders> repo)
        {
            _repoOrders = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("PlaceOrder")]
        public IActionResult Submit()
        {
            Orders newO = new Orders()
            {
                StoreId = Convert.ToInt32(TempData.Peek("CurrentStore")),
                UserId = Convert.ToInt32(TempData.Peek("CurrentUser")),
                PizzaAmount = 0,
                Cost = 0,
                OrderTime = DateTime.Now
            };

            var realOrder = _repoOrders.Addp(newO);
            TempData["CurrentOrder"] = realOrder.OrderId;
            return View("/Views/Ordering/Choice.cshtml");
        }

        public IActionResult Done()
        {
            Decimal result =Convert.ToDecimal(TempData["DecimalValue"]);
            Orders newO = new Orders()
            {
                OrderId = Convert.ToInt32(TempData.Peek("CurrentOrder")),
                OrderTime = DateTime.Now,
                PizzaAmount = Convert.ToInt32(TempData.Peek("PizzaAmount")),
                Cost = result
            };
            _repoOrders.Modifyp(newO);
            return View("/Views/Home/Index.cshtml");

        }
        public IActionResult HistoryPizzas()
        {
            string temp = TempData.Peek("CurrentUser").ToString();
            if (temp == null)
            {
                List<OrderViewModel> oVM = new List<OrderViewModel>();
                return View("/Views/User/History.cshtml", oVM);
            }
            else
            {
                var allOrders = _repoOrders.Getp(temp);
                List<OrderViewModel> oVM = new List<OrderViewModel>();
                foreach (var item in allOrders)
                {
                    OrderViewModel s = new OrderViewModel();
                    s.Cost = item.Cost;
                    s.PizzaAmount = item.PizzaAmount;
                    s.OrderedTime = item.OrderTime;
                    s.StoreID = item.StoreId;
                    oVM.Add(s);
                }
                return View("/Views/User/History.cshtml", oVM);
            }
        }
    }
}