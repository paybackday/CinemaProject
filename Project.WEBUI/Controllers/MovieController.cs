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
            if (Session["vip"] == null && Session["member"] == null)
            {
                TempData["noneLogin"] = "Seans saatlerini gorebilmek ve bilet satin alabilmek icin uye girisi yapiniz";
            }
            MovieVM defVM = new MovieVM
            {
                Movie = _mvRep.FirstOrDefault(x => x.ID == id),
                /*MovieActor*/
                MovieActors = _mvaRep.Where(x => x.MovieID == id)
            };

            return View(defVM);
        }

        //GET: All Movies
        public ActionResult Movie(int? page, int? genreID)
        {
            MovieVM mvm = new MovieVM
            {
                PagedMovies = genreID == null ? _mvRep.GetActives().ToPagedList(page ?? 1, 10) : _mvRep.Where(x => x.GenreID == genreID).ToPagedList(page ?? 1, 10),
                Genres = _genRep.GetActives(),
                MovieActors = _mvaRep.GetActives(),

            };
            if (mvm.PagedMovies.Count() == 0)
            {
                TempData["nullControl"] = "Bu türde film bulunamadı";
            }
            if (genreID != null) TempData["genreID"] = genreID;


            return View(mvm);
        }

        [HttpPost]
        public ActionResult QueryDate(int id, string date)
        {
            
            DateTime dateControl = Convert.ToDateTime(date);

            if (Session["vip"] != null)
            {
                DateTime dateVipQuery = DateTime.Now.AddDays(7); //VIP musteriler 7 gun oncesinden alabilir.
                MovieVM mvm = new MovieVM
                {
                    Movie = _mvRep.FirstOrDefault(x => x.ID == id),
                    Saloons = _salRep.GetActives(),
                    MovieSessionSaloons = _mssRep.Where(x => x.MovieID == id && ( x.Session.Time<=dateVipQuery || DateTime.Now>=x.Session.Time) && x.Session.Time.Day == dateControl.Day && x.Session.Time.Month == dateControl.Month && x.Session.Time.Year == dateControl.Year)
                };

                if (mvm.MovieSessionSaloons.Count==0)
                {
                    TempData["noTicket"] = "Uygun bilet bulunamadi. Lutfen tarih bilgisini tekrar kontrol ediniz.";
                }

                return PartialView(mvm);
            }

            else if (Session["member"] != null)
            {
                DateTime dateMemberQuery = DateTime.Now.AddDays(2); // Member icin bilet opsiyonu 2 gun oncesidir.

                MovieVM mvm = new MovieVM
                {
                    Movie = _mvRep.FirstOrDefault(x => x.ID == id),
                    Saloons = _salRep.GetActives(),
                    MovieSessionSaloons = _mssRep.Where(x => x.MovieID == id && (x.Session.Time <= dateMemberQuery || DateTime.Now>=x.Session.Time) && x.Session.Time.Day == dateControl.Day && x.Session.Time.Month == dateControl.Month && x.Session.Time.Year == dateControl.Year)
                };

                if (mvm.MovieSessionSaloons.Count==0)
                {
                    TempData["noTicket"] = "Uygun bilet bulunamadi. Lutfen tarih bilgisini tekrar kontrol ediniz.";
                }

                return PartialView(mvm);

            }

            return PartialView();

        }
    }
}