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
            if (TempData.Peek("CurrentUser") == null)
            {
                return View("/Views/Home/FailedSignIn.cshtml");
            }
            return RedirectToAction("HistoryPizzas","PlaceOrder");
        }

        public IActionResult Recent()
        {
            return View();
        }

        public IActionResult LoggingIn()
        {
            return View("/Views/Home/Login.cshtml");
        }

        [HttpPost]
        public IActionResult AttemptEnter()
        {
            TempData["ourName"] = HttpContext.Request.Form["UserName"].ToString();
            TempData["ourCode"] = HttpContext.Request.Form["PassCode"].ToString();
            return RedirectToAction("AttemptEnter", "UserLogIn");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Place()
        {
            if(TempData.Peek("CurrentUser")==null)
            {
                return View("/Views/Home/FailedSignIn.cshtml");
            }
            var allStores = _repoStores.Getp();
            List<StoreViewModel> sVM = new List<StoreViewModel>();
            foreach (var item in allStores)
            {
                StoreViewModel s = new StoreViewModel();
                s.StoreCode = item.StoreCode;
                s.StoreName = item.StoreName;
                s.StoreId = item.StoreId;
                sVM.Add(s);
            }
            return View(sVM);
        }
    }
}
