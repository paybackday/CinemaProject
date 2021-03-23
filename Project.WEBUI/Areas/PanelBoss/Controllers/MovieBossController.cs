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

    public class MovieBossController : Controller
    {
        MovieRepository _mvRep;
        public MovieBossController()
        {
            _mvRep = new MovieRepository();
        }
        // GET: PanelBoss/MovieBoss
        public ActionResult MovieList()
        {
            MovieVM mvm = new MovieVM
            {
                Movies = _mvRep.GetActives()
            };
            return View(mvm);
        }
    }
}