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
        SaleRepository _saleRep;
        MovieSessionSaloonRepository _mvpRep;
        public ReservationController()
        {
            _sRep = new SeatRepository();
            _mRep = new MovieRepository();
            _sesRep = new SessionRepository();
            _salRep = new SaloonRepository();
            _mvpRep = new MovieSessionSaloonRepository();
            _saleRep = new SaleRepository();
        }
        // GET: Reservation


        public ActionResult Seat(int movieID, int saloonID, int sessionID)
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
            if (selectedChoise == "reservation")
            {
                string[] reservationSeats = buyedSeats.Trim().Split(':');
                CheckoutVM cvm = new CheckoutVM()
                {
                    Movie = _mRep.FirstOrDefault(x => x.ID == movieID),
                    Session = _sesRep.FirstOrDefault(x => x.ID == sessionID),
                    Saloon = _salRep.FirstOrDefault(x => x.ID == saloonID),
                };

                TempData["choise"] = "Rezervasyon"; // Bilet turu tercihini kullaniciya gosterilmek icin olusuturulan TempData
                TempData["reservationSeats"] = buyedSeats.Trim(':'); //Secilen koltuklari kullaniciya gostemek icin olusturulan TempData.
                TempData.Keep();

                ViewBag.maxStudents = (reservationSeats.Count()) - 1;

                return View("CheckOutReservation", cvm);
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
                TempData.Keep();

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

        public ActionResult CheckOutReservation()
        {

            return View();
        }

        public ActionResult CheckOutSale()
        {

            return View();
        }


        public ActionResult ConfirmReservation(int movieID, int saloonID, int sessionID, int genreID, string ticketPrice, string seats)
        {
            int userID = 0;

            if (Session["member"] != null)
            {
                userID = (Session["member"] as AppUser).ID;
            }
            else if (Session["vip"] != null)
            {
                userID = (Session["vip"] as AppUser).ID;
            }

            Sale toBeAdded = new Sale()
            {
                AppUserID = userID,
                MovieID = movieID,
                SessionID = sessionID,
                GenreID = genreID,
                Type = ENTITIES.Enums.PaymentType.JustReservation,
                SaleType = ENTITIES.Enums.SaleType.Reservation,
                TicketPrice = Convert.ToDecimal(ticketPrice)
            };
            _saleRep.Add(toBeAdded);

            string[] selectedSeats = seats.Trim().Split(':');

            List<SeatListVM> characterNumber = new List<SeatListVM>();

            for (int i = 0; i < selectedSeats.Length; i++)
            {
                string[] seat = selectedSeats[i].Split('-');
                characterNumber.Add(new SeatListVM { Character = seat[0], Number = Convert.ToInt32(seat[1]) });
            }

            foreach (SeatListVM item in characterNumber)
            {
                Seat result = _sRep.FirstOrDefault(x => x.SaloonID == saloonID && x.SessionID == sessionID && x.Character == item.Character && x.Number == item.Number);
                result.SeatActive = true;
                _sRep.Update(result);
            }

            SaleResvervationTicketVM srtvm = new SaleResvervationTicketVM()
            {

                Character = selectedSeats[0],
                    Number = selectedSeats[1], //TODO
                    MovieName = toBeAdded.Movie.MovieName,
                    TicketPrice = Convert.ToDecimal(ticketPrice),
                    SalonID = saloonID,
                    SaleNo = toBeAdded.SaleNo//TODO: sayfa yenilendiginde yeni bir Guid ile yeni bir reservasyon olusturuyor... bunu engelle

                    
            };
          






          
            return View(srtvm);



        }
    }
}

