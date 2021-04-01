using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using Project.WEBUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Controllers
{
    public class AccountController : Controller
    {
        AppUserRepository apRep;
        UserProfileRepository apdRep;
        EmployeeRepository _empRep;
        public AccountController()
        {
            apRep = new AppUserRepository();
            apdRep = new UserProfileRepository();
            _empRep = new EmployeeRepository();
        }
     
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

          

           if (loginUser != null && item.Password==decrypted && loginUser.Role==ENTITIES.Enums.UserRole.Member)
            {
                if (!loginUser.Active)
                {
                    return AktifKontrol();
                }
                Session["member"] = loginUser;
                return RedirectToAction("Index", "Home");
            }//If catched user is a member
            else if (loginUser != null && item.Password == decrypted && loginUser.Role == ENTITIES.Enums.UserRole.Vip)
            {
                if (!loginUser.Active)
                {
                    return AktifKontrol();
                }
                Session["vip"] = loginUser;
                return RedirectToAction("Index", "Home");
            }//If catched user is a vip

           

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
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LostPassword() {

            return View();
        }

        [HttpPost]
        public ActionResult LostPassword(AppUserVM apvm) {
            AppUser resetPassUser = apRep.FirstOrDefault(x => x.Email == apvm.AppUser.Email);
            if (resetPassUser!=null)
            {
                string gonderilecekMail = "Şifrenizi yanda bulunan bağlantıya tıklayarak sıfırlayabilirsiniz. https://localhost:44390/Account/ResetPassword/" + resetPassUser.ActivationCode;
                MailSender.Send(receiver: resetPassUser.Email, body: gonderilecekMail, subject: "Şifre Sıfırlama İsteği");
                ViewBag.Bilgi = "Şifre sıfırlama bağlantınız email adresinize başarılı bir şekilde gönderilmiştir.";
            }
            else
            {
                ViewBag.Bilgi = "Kayıtlı kullanıcı bilgisi bulunamadı";
            }
            return View();
        }

        public ActionResult ResetPassword(Guid id) {
            AppUserVM apvm = new AppUserVM();
            apvm.AppUser = apRep.FirstOrDefault(x => x.ActivationCode == id);

            return View(apvm);
        }

        [HttpPost]
        public ActionResult ResetPassword([Bind(Prefix ="AppUser")] AppUser item) {
            if (!ModelState.IsValid) //Server Side Validation
            {
                return View();
            }
            AppUser toBeUpdated = apRep.FirstOrDefault(x => x.ActivationCode == item.ActivationCode);
            toBeUpdated.Password = DantexCrypt.Crypt(item.Password);
            toBeUpdated.ConfirmPassword = DantexCrypt.Crypt(item.ConfirmPassword);
            apRep.Update(toBeUpdated);
            
            TempData["ResetInfo"] = "Şifreniz başarılı bir şekilde güncellenmiştir.";

            return RedirectToAction("Login");
        }

        public ActionResult SetVip() {
            return View();
        }

        [HttpPost]
        public ActionResult SetVip(PaymentVM pvm) {
            bool result;
            pvm.TicketPrice = 100; //VIP Ucreti
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44391/api/");
                Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("Payment/ReceivePayment", pvm);

                HttpResponseMessage sonuc;

                try
                {
                    sonuc = postTask.Result;
                }
                catch (Exception)
                {
                    TempData["connectionDenial"] = "Banka bağlantıyı reddetti";
                    return RedirectToAction("Index", "Home");
                }

                if (sonuc.IsSuccessStatusCode)
                {
                    result = true;
                }
                else result = false;


                if (result)
                {
                    AppUser user = (Session["member"] as AppUser);
                    user.Role = ENTITIES.Enums.UserRole.Vip;
                    apRep.Update(user);
                    Session["vip"] = user;
                    Session.Remove("member");
                    TempData["beVIPSuccess"] = "VIP'ye gecis isleminiz basariyla gerceklestirilmistir.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["beVIPFailed"] = "VIP'ye gecis isleminizde bir sorun olustu. Lutfen daha sonra tekrar deneyiniz";
                    return RedirectToAction("SetVip", "Account");
                }
            }
        }
    }
}