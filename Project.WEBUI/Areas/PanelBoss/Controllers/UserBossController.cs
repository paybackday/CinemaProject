using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.WEBUI.AuthenticationClasses;
using Project.WEBUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Areas.PanelBoss.Controllers
{
    [BossAuthentication]

    public class UserBossController : Controller
    {
        AppUserRepository _apRep;
        UserProfileRepository _upRep;
        public UserBossController()
        {
            _apRep = new AppUserRepository();
            _upRep = new UserProfileRepository();
        }
        // GET: PanelBoss/UserBoss
        public ActionResult UserList()
        {
            AppUserVM apvm = new AppUserVM
            {
                AppUsers = _apRep.GetActives(),
                UserProfiles = _upRep.GetActives()
            };
            return View(apvm);
        }
    }
}