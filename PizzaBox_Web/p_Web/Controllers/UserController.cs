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
    public class UserController : Controller
    {
        private readonly IRepository<Stores> _repoStores;
        public UserController(IRepository<Stores> repo)
        {
            _repoStores = repo;
        }

        [Route("User")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult History()
        {
            ////if (pdb.Stores.Any(e => e.StoreName == p.StoreName))
            ////    return null;
            Stores s = new Stores()
            {
                StoreName = "Walmart",
                StoreCode = "Dumdums"
            };
            _repoStores.Addp(s);

            ////pdb.Stores.Add(p);
            ////pdb.SaveChanges();
            ////var a = pdb.Stores.FirstOrDefault(d => d.StoreName == p.StoreName);
            ////Console.WriteLine($"Added Store {a.StoreName} to Table 'Stores'");
            ////return a;

            return View();
        }

        public IActionResult Place()
        {
            var allStores = _repoStores.Getp();
            List<StoreViewModel> sVM = new List<StoreViewModel>();
            foreach(var item in allStores)
            {
                StoreViewModel s = new StoreViewModel();
                s.StoreCode = item.StoreCode;
                s.StoreName = item.StoreName;
                s.StoreId = item.StoreId;
                sVM.Add(s);
            }
            return View(sVM);
        }
        public IActionResult Recent()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
