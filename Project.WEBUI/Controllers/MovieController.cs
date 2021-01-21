using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.WEBUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Controllers
{
    public class MovieController : Controller
    {
        MovieRepository _mvRep;
        MovieActorRepository _mvaRep;
        ActorRepository _actRep;
        public MovieController()
        {
            _mvRep = new MovieRepository();
            _mvaRep = new MovieActorRepository();
            _actRep = new ActorRepository();
        }
        // GET: Movie
        public ActionResult Single(int id)
        {
            MovieVM mvm = new MovieVM
            {
                Movie = _mvRep.FirstOrDefault(x => x.ID == id),
                /*MovieActor*/
                MovieActors = _mvaRep.Where(x=>x.MovieID==id) 
            };
            return View(mvm);
        }
    }
}