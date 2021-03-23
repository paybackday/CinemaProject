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

    public class SaloonBossController : Controller
    {
        // GET: PanelBoss/SaloonBoss
        SaloonRepository _salRep;
        public SaloonBossController()
        {
            _salRep = new SaloonRepository();
        }
        public ActionResult SaloonList()
        {
            SaloonVM svm = new SaloonVM
            {
                Saloons = _salRep.GetActives()
            };
            return View(svm);
        }
    }
}