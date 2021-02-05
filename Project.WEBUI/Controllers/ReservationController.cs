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
        SessionRepository _sesRep;
        public ReservationController()
        {
            _sRep = new SeatRepository();
            _sesRep = new SessionRepository();
        }
        // GET: Reservation
       
        public ActionResult Seat(int MovieID,int SaloonID,int SessionID)
        {
            Session selectedSession = _sesRep.Find(SessionID);
            SeatVM svm = new SeatVM
            {
                Seats = _sRep.Where(x => x.SeatActive == false && x.SaloonID == SaloonID),
                Price = selectedSession.Price
            };

            svm.SeatLists = new List<SeatListVM>();

            for (int i = 0; i < svm.Seats.Count; i++)
            {
                Seat seat = svm.Seats[i];

                SeatListVM seatList = svm.SeatLists.Find(x => x.Character == seat.Character);
                if (seatList == null)
                {
                    seatList = new SeatListVM()
                    {
                        SaloonID = seat.SaloonID,
                        Seats = new List<Seat>(),
                        Character = seat.Character
                    };
                    svm.SeatLists.Add(seatList);
                }

                seatList.Seats.Add(seat);
            }

            return View(svm);
        }

        public ActionResult CheckOutView(string buyedSeats) //toDO: koltuklari incele. Algoritmayi kur.
        {
            
            string[] seats = buyedSeats.Trim().Split(':');
            //for (int i = 0; i < seats.Length; i++)
            //{
            //    string[] seat = seats[i].Split('-');
            //    seat[0] = "Character";
            //    seat[1] = "Numara";
            //}
            return View();
        }
    }
}