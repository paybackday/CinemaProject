using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using Project.WEBUI.AuthenticationClasses;
using Project.WEBUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Areas.Panel.Controllers
{
    [AllRolePassedAuthentication]

    public class MovieDashController : Controller
    {

        MovieRepository _mvRep;
        MovieActorRepository _maRep;
        GenreRepository _genRep;
  
        public MovieDashController()
        {
            _mvRep = new MovieRepository();
            _maRep = new MovieActorRepository();
            _genRep = new GenreRepository();
          
        }
        // GET: Panel/Movie
        public ActionResult MovieList()
        {
            MovieVM mvm = new MovieVM
            {
               
                Movies = _mvRep.GetActives(),
            };
            return View(mvm);
        }

        public ActionResult AddMovie()
        {
            MovieVM mvm = new MovieVM
            {
                Movie = new Movie(),
                Genres = _genRep.GetActives()

            };
            return View(mvm);
        }
        [HttpPost]
        public ActionResult AddMovie([Bind(Prefix ="Movie")]Movie item, HttpPostedFileBase resim)
        {
            item.MovieImagePath = ImageUploader.UploadImage("~/Pictures/", resim);
            _mvRep.Add(item);
            return RedirectToAction("MovieList");
        }
        public ActionResult DeleteMovie(int id)
        {
            _mvRep.Delete(_mvRep.Find(id));
            return RedirectToAction("MovieList");
        }

        public ActionResult UpdateMovie(int id)
        {
            MovieVM mvm = new MovieVM
            {
                Movie = _mvRep.Find(id),
                Genres = _genRep.GetActives()
            };
            return View(mvm);
        }
        [HttpPost]
        public ActionResult UpdateMovie([Bind(Prefix ="Movie")]Movie item,HttpPostedFileBase resim)
        {

            item.MovieImagePath = ImageUploader.UploadImage("~/Pictures/", resim);
         
            _mvRep.Update(item);
            return RedirectToAction("MovieList");
        }
    }
}