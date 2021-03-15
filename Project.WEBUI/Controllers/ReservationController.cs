using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.WEBUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Controllers
{
    public class ReservationController : Controller
    {
        SeatRepository _sRep;
        MovieRepository _mRep;
        SessionRepository _sesRep;
        SaloonRepository _salRep;
        MovieSessionSaloonRepository _mvpRep;
        public ReservationController()
        {
            _sRep = new SeatRepository();
            _mRep = new MovieRepository();
            _sesRep = new SessionRepository();
            _salRep = new SaloonRepository();
            _mvpRep = new MovieSessionSaloonRepository();
        }
        // GET: Reservation
       
        
        public ActionResult Seat(int movieID,int saloonID,int sessionID)
        {
            Session selectedSession = _sesRep.Find(sessionID);
            List<Seat> seats = _sRep.Where(x => x.SessionID == sessionID && x.SaloonID == saloonID);
            SeatVM svm = new SeatVM
            {
                //Tum koltuklari cek.
                Seats = seats,//TODO:2.ci seans icin gelmiyor koltular.
                Price = selectedSession.Price
            };
            
            TempData["movieID"] = movieID;
            TempData["saloonID"] = saloonID;
            TempData["sessionID"] = sessionID;


            //svm.SeatLists = new List<SeatListVM>();

            //for (int i = 0; i < svm.Seats.Count; i++)
            //{
            //    Seat seat = svm.Seats[i];

            //    SeatListVM seatList = svm.SeatLists.Find(x => x.Character == seat.Character);
            //    if (seatList == null)
            //    {
            //        seatList = new SeatListVM()
            //        {
            //            SaloonID = seat.SaloonID,
            //            Seats = new List<Seat>(),
            //            Character = seat.Character
            //        };
            //        svm.SeatLists.Add(seatList);
            //    }

            //    seatList.Seats.Add(seat);
            //}

            return View(svm);
        }

        
        [HttpPost]
        public ActionResult CheckOutView(string selectedChoise, string buyedSeats, int movieID, int saloonID, int sessionID) 
        {
            if (selectedChoise=="reservation")
            {
                string[] reservationSeats = buyedSeats.Trim().Split(':');
                CheckoutVM cvm = new CheckoutVM()
                {
                    Movie=_mRep.FirstOrDefault(x=>x.ID==movieID),
                    Session=_sesRep.FirstOrDefault(x=>x.ID==sessionID),
                    Saloon=_salRep.FirstOrDefault(x=>x.ID==saloonID),
                };
                
                TempData["choise"] = "Rezervasyon"; // Bilet turu tercihini kullaniciya gosterilmek icin olusuturulan TempData
                TempData["reservationSeats"] = buyedSeats.Trim(':'); //Secilen koltuklari kullaniciya gostemek icin olusturulan TempData.

                
                ViewBag.maxStudents = (reservationSeats.Count()) - 1;

                return View("CheckOutReservation",cvm);
            }
            else if (selectedChoise == "sale")
            {
                string[] saleSeats = buyedSeats.Trim().Split(':');
                CheckoutVM cvm = new CheckoutVM()
                {
                    Movie = _mRep.FirstOrDefault(x => x.ID == movieID),
                    Session = _sesRep.FirstOrDefault(x => x.ID == sessionID),
                    Saloon = _salRep.FirstOrDefault(x => x.ID == saloonID),
                };

                TempData["choise"] = "Satış";
                TempData["saleSeats"] = buyedSeats.Trim(':');

                ViewBag.maxStudents = (saleSeats.Count()) - 1;


                return View("CheckOutSale", cvm);
            }
            string[] seats = buyedSeats.Trim().Split(':');
            //for (int i = 0; i < seats.Length; i++)
            //{
            //    string[] seat = seats[i].Split('-');
            //    seat[0] = "Character";
            //    seat[1] = "Numara";
            //}
            return View();
        }

        public ActionResult CheckOutReservation() {

            return View();
        }

        public ActionResult CheckOutSale() {

            return View();
        }
    }
}