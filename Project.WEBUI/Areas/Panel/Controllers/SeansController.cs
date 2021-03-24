using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
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
    //[BoxOfficeSupervisorAuthentication]
    //[ManagementAuthentication]
    //[BookingClerkAuthentication]
    public class SeansController : Controller
    {
        // GET: Panel/Seans
        SessionRepository _sRep;
        MovieSessionSaloonRepository _mssRep;
        MovieRepository _mRep;
        SaloonRepository _salRep;
        SeatRepository _seaRep;

        public SeansController()
        {
            _sRep = new SessionRepository();
            _mssRep = new MovieSessionSaloonRepository();
            _mRep = new MovieRepository();
            _salRep = new SaloonRepository();
            _seaRep = new SeatRepository();
        }
        public ActionResult SeansList()
        {
            SessionVM svm = new SessionVM
            {
                Sessions = _sRep.GetActives()
            };

            return View(svm);
        }

        public ActionResult AddSession()
        {
            SessionVM svm = new SessionVM
            {
                Session = new Session()
            };
            return View(svm);
        }

        [HttpPost]
        public ActionResult AddSession([Bind(Prefix = "Session")] Session item)
        {
            if (!ModelState.IsValid)
            {
                return View("AddSession");
            }
            ViewBag.error = "Seans saati veya tarih eklenmedi lütfen tekrar deneyiniz";//TODO:bakılacak.
            _sRep.Add(item);
            return RedirectToAction("SeansList");
        }
        public ActionResult DeleteSession(int id)
        {
            _sRep.Destroy(_sRep.Find(id));
            return RedirectToAction("SeansList");

        }

        public ActionResult AddNotation(/*int movieId, int sessionId, int saloonId*/)
        {
            MovieSessionSaloonVM mss = new MovieSessionSaloonVM
            {
                Movies = _mRep.GetActives(),
                Saloons = _salRep.GetActives(),

                Sessions = _sRep.GetActives()
            };

            return View(mss);
        }
        [HttpPost]
        public ActionResult AddNotation(MovieSessionSaloonVM item)
        {
            //MovieSessionSaloon added = _mssRep.FirstOrDefault(x=> x.MovieID == item.Movie.ID && x.SessionID == item.Session.ID && x.SaloonID == item.Saloon.ID);


            MovieSessionSaloon mss = new MovieSessionSaloon
            {
                MovieID = item.Movie.ID,
                SessionID = item.Session.ID,
                SaloonID = item.Saloon.ID
            };

           
            _mssRep.Add(mss);

            for (char j = 'A'; j < 'I'; j++)
            {
                for (int k = 1; k <= 14; k++)
                {
                    Seat seat = new Seat();
                    seat.SeatActive = false;
                    seat.SaloonID = item.Saloon.ID;
                    seat.SessionID = item.Session.ID;
                    seat.Character = Convert.ToString(j);
                    seat.Number = k;
                    _seaRep.Add(seat);
                }
            }

            //added.SessionID = item.Session.ID;
            //added.SaloonID = item.Saloon.ID;



            return RedirectToAction("SeansList");
        }



    }
}