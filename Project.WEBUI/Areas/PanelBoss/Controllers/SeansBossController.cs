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

    public class SeansBossController : Controller
    {
        // GET: PanelBoss/SeansBoss
        SessionRepository _sesRep;
        MovieRepository _mRep;
        SaloonRepository _sRep;
        MovieSessionSaloonRepository _mssRep;
        public SeansBossController()
        {
            _sesRep = new SessionRepository();
            _mRep = new MovieRepository();
            _sRep = new SaloonRepository();
            _mssRep = new MovieSessionSaloonRepository();
        }
        public ActionResult SeansList()
        {
            SessionVM svm = new SessionVM
            {
                Sessions = _sesRep.GetActives()
            };
            return View(svm);
        }

        public ActionResult GetNotation()
        {
            MovieSessionSaloonVM mss = new MovieSessionSaloonVM
            {
                MovieSessionSaloons = _mssRep.GetActives(),
                Movies = _mRep.GetActives(),
                Saloons = _sRep.GetActives(),

                Sessions = _sesRep.GetActives()
            };

            return View(mss);
        }
    }
}