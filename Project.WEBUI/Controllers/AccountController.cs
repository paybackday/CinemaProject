using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
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
        public ActionResult Register(AppUserVM apvm) {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }

            apvm.AppUser.Password = DantexCrypt.Crypt(apvm.AppUser.Password);
            
            apvm.AppUser.ConfirmPassword = DantexCrypt.Crypt(apvm.AppUser.ConfirmPassword);

            

            if (apRep.Any(x=>x.Email==apvm.AppUser.Email))
            {
                ViewBag.Mevcut = "Bu Email adresine kayıtlı hesap bulunmaktadır.";
                return View();
            }
            string gonderilecekMail = "Tebrikler kayıt olma işleminiz başarılı bir şekilde gerçekleştirilmiştir. Hesabınızı aktif etmek için https://localhost:44390/Account/Activation/" + apvm.AppUser.ActivationCode + " linkine tıklamanız yeterlidir.";

            MailSender.Send(apvm.AppUser.Email, body: gonderilecekMail, subject: "Hesap Aktivasyon");

            apRep.Add(apvm.AppUser); //One to one relation on first

            if (!string.IsNullOrEmpty(apvm.UserProfile.FirstName) || !string.IsNullOrEmpty(apvm.UserProfile.LastName) || apvm.UserProfile.Gender!=0 || !string.IsNullOrEmpty(apvm.UserProfile.MobilePhone))
            {
                apvm.UserProfile.ID = apvm.AppUser.ID;
                apdRep.Add(apvm.UserProfile);
            }

            return View("RegisterOk");
        }

        public ActionResult Activation(Guid id) {
            AppUser toBeActivated = apRep.FirstOrDefault(x => x.ActivationCode == id);
            if (toBeActivated!=null)
            {
                toBeActivated.Active = true;
                toBeActivated.ActivationCode = Guid.NewGuid();
                apRep.Update(toBeActivated);
                TempData["accountActive"] = "Hesabınız aktifleştirilmiştir.";
                RedirectToAction("Login");
            }

            TempData["accountActive"] = "Aktif edilecek hesap bulunamadı";
            return RedirectToAction("Register");
        }

        public ActionResult RegisterOk() {

            return View();
        }

    }
}