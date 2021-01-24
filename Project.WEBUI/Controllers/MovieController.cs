using PagedList;
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
        MovieSessionSaloonRepository _mssRep;
        SaloonRepository _salRep;
        GenreRepository _genRep;
        public MovieController()
        {
            _mvRep = new MovieRepository();
            _mvaRep = new MovieActorRepository();
            _actRep = new ActorRepository();
            _mssRep = new MovieSessionSaloonRepository();
            _salRep = new SaloonRepository();
            _genRep = new GenreRepository();
        }
        // GET: Movie
        public ActionResult Single(int id)
        {
            MovieVM mvm = new MovieVM
            {
                Movie = _mvRep.FirstOrDefault(x => x.ID == id),
                /*MovieActor*/
                MovieActors = _mvaRep.Where(x => x.MovieID == id),
                MovieSessionSaloons = _mssRep.Where(x => x.MovieID == id),
                Saloons = _salRep.GetActives()
            };
            return View(mvm);
        }

        //GET: All Movies
        public ActionResult Movie(int? page,int? genreID) {
            MovieVM mvm = new MovieVM
            {
                PagedMovies = genreID==null? _mvRep.GetActives().ToPagedList(page??1,10):_mvRep.Where(x=>x.GenreID==genreID).ToPagedList(page??1,10),
                Genres=_genRep.GetActives(),
                MovieActors=_mvaRep.GetActives(),
                
            };
            if (mvm.PagedMovies.Count()==0)
            {
                TempData["nullControl"] = "Bu türde film bulunamadı";
            }
            if (genreID != null) TempData["genreID"] = genreID;
            

            return View(mvm);
        }
    }
}