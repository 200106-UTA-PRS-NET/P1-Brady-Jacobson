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
            return View(sVM);
        }

        public IActionResult Preset()
        {
            return View();
        }
        public IActionResult Custom()
        {
            return View();
        }
    }
}