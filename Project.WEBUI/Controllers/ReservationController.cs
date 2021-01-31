using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
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
        public ReservationController()
        {
            _sRep = new SeatRepository();
        }
        // GET: Reservation
        public ActionResult Seat(int MovieID,int SaloonID,int SessionID)
        {
            SeatVM svm = new SeatVM
            {
                Seats = _sRep.Where(x => x.SeatActive == false && x.SaloonID==SaloonID)
            };
            return View(svm);
        }
    }
}