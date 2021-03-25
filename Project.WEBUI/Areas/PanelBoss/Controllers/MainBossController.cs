using Project.WEBUI.AuthenticationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Areas.PanelBoss.Controllers
{
    [BossAuthentication]
    public class MainBossController : Controller
    {
        [BossAuthentication]
        // GET: PanelBoss/MainBoss
        public ActionResult Index()
        {
            return View();
        }
    }
}