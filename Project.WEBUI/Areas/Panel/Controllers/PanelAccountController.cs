using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using Project.WEBUI.AuthenticationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Areas.Panel.Controllers
{
    
    public class PanelAccountController : Controller
    {
        // GET: Panel/PanelAccount
        EmployeeRepository _empRep;
        public PanelAccountController()
        {
            _empRep = new EmployeeRepository();
        }
        public ActionResult EmployeeLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeLogin([Bind(Prefix = ("Employee"))] Employee item)
        {
            Employee loginEmployee = _empRep.FirstOrDefault(x => x.Email == item.Email);

            string decrypted = DantexCrypt.DeCrypt(loginEmployee.Password);

            if (loginEmployee == null)
            {
                ViewBag.Hata = "Bu email adresine kayıtlı çalışan bulunamadı";
                return View();
            }
            else
            {



                if (loginEmployee != null && item.Password == decrypted && loginEmployee.EmployeeType == ENTITIES.Enums.EmployeeType.Boss)
                {

                    Session["boss"] = loginEmployee;
                    return RedirectToAction("Index", "Main");
                }//If catched user is a boss
                else if (loginEmployee != null && item.Password == decrypted && loginEmployee.EmployeeType == ENTITIES.Enums.EmployeeType.Management)
                {

                    Session["management"] = loginEmployee;
                    return RedirectToAction("Index", "Main");
                }//If catched user is a management
                else if (loginEmployee != null && item.Password == decrypted && loginEmployee.EmployeeType == ENTITIES.Enums.EmployeeType.BookingClerk)
                {

                    Session["bookingClerk"] = loginEmployee;
                    return RedirectToAction("Index", "Main");
                }//If catched user is a bookingClerk
                else if (loginEmployee != null && item.Password == decrypted && loginEmployee.EmployeeType == ENTITIES.Enums.EmployeeType.BoxOfficeSupervisor)
                {

                    Session["boxSupervisor"] = loginEmployee;
                    return RedirectToAction("Index", "Main");
                }//If catched user is a boxSupervisor
                else
                {
                    ViewBag.Hata = "Email adresi veya şifrenizi hatalı girdiniz.";
                    return View();
                }
            }
        }
    }
}