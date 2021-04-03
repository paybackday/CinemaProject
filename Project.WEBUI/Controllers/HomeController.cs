using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.WEBUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.COMMON.Tools;

namespace Project.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        MovieRepository _mvRep;

        public HomeController()
        {
            _mvRep = new MovieRepository();
        }
        // GET: Home
        public ActionResult Index()
        {
            MovieVM mvm = new MovieVM
            {
                Movies = _mvRep.GetActives()

            };
            return View(mvm);
        }

        public ActionResult About()
        {
            return View();
        }
        

    }
}