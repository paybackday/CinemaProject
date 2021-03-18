using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.WEBUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Areas.Panel.Controllers
{
    public class MovieController : Controller
    {

        MovieRepository _mvRep;
        MovieActorRepository _maRep;
        public MovieController()
        {
            _mvRep = new MovieRepository();
            _maRep = new MovieActorRepository();
        }
        // GET: Panel/Movie
        public ActionResult MovieList()
        {
            MovieVM mvm = new MovieVM
            {//TODO: Buraya PageList Koyacam unutma ve Actor isimleri de gelmyior system generic diyor onuda ayarlıcam
                Movies = _mvRep.GetActives(),
                MovieActors = _maRep.GetActives()
                
            };
            return View(mvm);
        }
    }
}