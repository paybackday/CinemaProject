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
        /*[HttpPost]
        public ActionResult GetName(int id) {
            AppUserVM apvm = new AppUserVM
            {
                UserProfile = apdRep.FirstOrDefault(x => x.ID == id)
            };
            return PartialView("GetName",apvm);
        }*/
        private ActionResult AktifKontrol() {
            ViewBag.Hata = "Hesabınız aktif değildir. Lütfen hesabınızı email adresinize gönderdiğimiz bağlantı ile aktif hale getirin";
            return View("Login");
        
        }

        public ActionResult Login() {

            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Prefix ="AppUser")] AppUser item) 
        {
            AppUser loginUser = apRep.FirstOrDefault(x => x.Email == item.Email);
            if (loginUser==null) //Eğer sorgudan kullanıcı gelmiyorsa
            {
                ViewBag.Hata = "Bu email adresine kayıtlı kullanıcı bulunamadı";
                return View();
            }

            string decrypted = DantexCrypt.DeCrypt(loginUser.Password);

            if (loginUser != null && item.Password == decrypted && loginUser.Role == ENTITIES.Enums.UserRole.Admin)
            {
                if (!loginUser.Active)
                {
                    return AktifKontrol();
                }
                Session["admin"] = loginUser;
                return RedirectToAction("Register", "Account");
            }//If catched user is a admin

            else if (loginUser != null && item.Password==decrypted && loginUser.Role==ENTITIES.Enums.UserRole.Member)
            {
                if (!loginUser.Active)
                {
                    return AktifKontrol();
                }
                Session["member"] = loginUser;
                return RedirectToAction("Index", "Home");
            }//If catched user is a member

            else
            {
                ViewBag.Hata = "Email adresi veya şifrenizi hatalı girdiniz.";
                return View();
            }
        }



        // GET: Register
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
              return  RedirectToAction("Login");
            }

            TempData["accountActive"] = "Aktif edilecek hesap bulunamadı";
            return RedirectToAction("Register");
        }

        public ActionResult RegisterOk() {

            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("member");
            return RedirectToAction("Index", "Home");
        }

    }
}