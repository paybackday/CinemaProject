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

    public class ActorBossController : Controller
    {
        ActorRepository _acRep;
     
        // GET: PanelBoss/ActorBoss
        public ActorBossController()
        {
            _acRep = new ActorRepository();
           
        }
        public ActionResult ActorList()
        {
            ActorVM avm = new ActorVM
            {
                Actors = _acRep.GetActives(),
         
            };
            return View(avm);
        }
    }
}