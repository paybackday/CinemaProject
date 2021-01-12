using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.WEBUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Controllers
{
    public class AccountController : Controller
    {
        AppUserRepository apRep;
        UserProfileRepository apdRep;
        public AccountController()
        {
            apRep = new AppUserRepository();
            apdRep = new UserProfileRepository();
        }
        // GET: Account
        public ActionResult Register() //Kayit olma islemleri
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUserVM item) {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }

            return View();
        }
    }
}