using System;
using System.Collections.Generic;
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
    public class OrderingController : Controller
    {
        private readonly IRepository<Stores> _repoStores;
        public OrderingController(IRepository<Stores> repo)
        {
            _repoStores = repo;
        }

        [Route("Ordering")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Return()
        {
            return View("/Views/Ordering/Choice.cshtml");
        }

        [HttpGet("{StoreId}")]
        public IActionResult Choice([FromRoute]int StoreId)
        {
            var thisStore = _repoStores.UseIDFindStore(StoreId);
            StoreViewModel sVM = new StoreViewModel()
            {
                StoreCode = thisStore.StoreCode,
                StoreId = thisStore.StoreId,
                StoreName = thisStore.StoreName
            };
            TempData["CurrentStore"] = sVM.StoreId;
            TempData["PizzaAmount"] = 0;
            TempData["PizzaCost"] = 0;
            return RedirectToAction("Submit","PlaceOrder");
        }

        public IActionResult Preset()
        {
            return View();
        }
        public IActionResult Custom()
        {
            return View();
        }

        public IActionResult Submit()
        {
            return RedirectToAction("Done", "PlacePizza");
        }
        public IActionResult Preview()
        {
            return RedirectToAction("PreviewPizzas", "PlacePizza");
        }
        public IActionResult AddtoOrderH()
        {
            return RedirectToAction("AddtoOrderH", "PlacePizza");
        }

        public IActionResult AddtoOrderB()
        {
            return RedirectToAction("AddtoOrderB", "PlacePizza");
        }

        public IActionResult AddtoOrderA()
        {
            return RedirectToAction("AddtoOrderA", "PlacePizza");
        }

        public IActionResult AddtoOrderI()
        {
            return RedirectToAction("AddtoOrderI", "PlacePizza");
        }
       
        public IActionResult AddtoOrderC()
        {
            return RedirectToAction("AddtoOrderC", "PlacePizza");
        }
    }
}