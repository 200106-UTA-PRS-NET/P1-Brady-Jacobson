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
    public class UserLogInController : Controller
    {
        private readonly IRepository<Users> _repoUsers;
        public UserLogInController(IRepository<Users> repo)
        {
            _repoUsers = repo;
        }

        [Route("UserLogIn")]
        public IActionResult AttemptEnter()
        {
            try
            {
                string un = TempData["ourName"].ToString();
                string uc = TempData["ourCode"].ToString();
                Users newU = new Users()
                {
                    UserName = un,
                    UserCode = uc
                };
                var outcome = _repoUsers.AccessP(newU);
                if(outcome==null)
                {
                    return View("/Views/Home/FailedSignIn.cshtml");
                }
                else
                {
                    TempData["CurrentUser"] = outcome.UserId.ToString();
                    return View("/Views/Home/Index.cshtml");
                }
            }
            catch
            {
                return View("/Views/Home/FailedSignIn.cshtml");
            }
        }
    }
}