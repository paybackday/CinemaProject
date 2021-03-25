using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.WEBUI.AuthenticationClasses;
using Project.WEBUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Areas.Panel.Controllers
{
    [AllRolePassedAuthentication]
   
    public class UserController : Controller
    {
        // GET: Panel/User
        AppUserRepository _uRep;
        UserProfileRepository _upRep;
        public UserController()
        {
            _uRep = new AppUserRepository();
            _upRep = new UserProfileRepository();
        }
        // GET: Panel/User
        public ActionResult UserList()
        {
            AppUserVM apvm = new AppUserVM
            {
                AppUsers = _uRep.GetActives(),
                UserProfiles = _upRep.GetActives()

            };
            return View(apvm);
        }

        public ActionResult DeleteUser(int id)
        {
            _uRep.Delete(_uRep.Find(id));
            _upRep.Delete(_upRep.Find(id));



            return RedirectToAction("UserList", "User", new { Area = "Panel" });
        }

        public ActionResult UpdateUser(int id)
        {
            AppUserVM apvm = new AppUserVM
            {
                AppUser = _uRep.Find(id),
                UserProfile = _upRep.Find(id)
            };
            return View(apvm);
        }

        [HttpPost]
        public ActionResult UpdateUser(AppUserVM apvm)
        {
            
          
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser toBeUpdatedUser = _uRep.FirstOrDefault(x => x.ID == apvm.AppUser.ID);
            UserProfile toBeUpdatedUserProfile = _upRep.FirstOrDefault(x => x.ID == apvm.UserProfile.ID);


           

            toBeUpdatedUser.Email = apvm.AppUser.Email;
            toBeUpdatedUser.Password = apvm.AppUser.Password;
            toBeUpdatedUser.ConfirmPassword = apvm.AppUser.ConfirmPassword;
            toBeUpdatedUser.Role = apvm.AppUser.Role;

            toBeUpdatedUserProfile.FirstName = apvm.UserProfile.FirstName;
            toBeUpdatedUserProfile.LastName = apvm.UserProfile.LastName;
            toBeUpdatedUserProfile.MobilePhone = apvm.UserProfile.MobilePhone;
            toBeUpdatedUserProfile.Gender = apvm.UserProfile.Gender;
            toBeUpdatedUserProfile.Address = apvm.UserProfile.Address;


            _uRep.Update(toBeUpdatedUser);
            _upRep.Update(toBeUpdatedUserProfile);

            TempData["updateUser"] = $"{toBeUpdatedUserProfile.FirstName} {toBeUpdatedUserProfile.LastName} kişisi başarıyla güncellenmiştir";


            return RedirectToAction("UserList", "User", new { Area = "Panel" });
        }
    }
}