using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.WEBUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
        SaleSeatRepository _saleSeatRep;
        public ReservationController()
        {
            _sRep = new SeatRepository();
            _mRep = new MovieRepository();
            _sesRep = new SessionRepository();
            _salRep = new SaloonRepository();
            _mvpRep = new MovieSessionSaloonRepository();
            _saleRep = new SaleRepository();
            _saleSeatRep = new SaleSeatRepository();
        }
        // GET: Reservation


        public ActionResult Seat(int movieID, int saloonID, int sessionID)
        {
            Session ses = _sesRep.FirstOrDefault(x => x.ID == sessionID);
            if (DateTime.Now<=ses.Time && DateTime.Now.AddMinutes(30)>=ses.Time)
            {
                List<Sale> list = _saleRep.Where(x => x.SaleType == ENTITIES.Enums.SaleType.Reservation && x.SessionID == sessionID);
                List<int> toBeUpdatedSeatsId;
                for (int i = 0; i < list.Count; i++)
                {
                    int saleId = list[i].ID;
                    toBeUpdatedSeatsId = _saleSeatRep.Where(x => x.SaleID == saleId).Select(x=>x.SeatID).ToList();
                    foreach (int id in toBeUpdatedSeatsId)
                    {
                        Seat seat=_sRep.FirstOrDefault(x => x.ID == id);
                        seat.SeatActive = false;
                        _sRep.Update(seat);
                    }
                    _saleSeatRep.DeleteRange(_saleSeatRep.Where(x => x.SaleID == saleId));
                    _saleRep.Delete(list[i]);
                }
            }

            Session selectedSession = _sesRep.Find(sessionID);
            List<Seat> seats = _sRep.Where(x => x.SessionID == sessionID && x.SaloonID == saloonID);
            SeatVM svm = new SeatVM
            {
                //Tum koltuklari cek.
                Seats = seats,
                Price = selectedSession.Price
            };

            TempData["movieID"] = movieID;
            TempData["saloonID"] = saloonID;
            TempData["sessionID"] = sessionID;
            TempData["sessionTime"] = ses.Time;




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

        [HttpPost]
        public ActionResult ConfirmReservation(int movieID, int saloonID, int sessionID, int genreID, string ticketPrice, string seats)
        {
            decimal toBeConverted = Convert.ToDecimal(ticketPrice);

            var query = _saleRep.FirstOrDefault(x => x.MovieID == movieID && x.SessionID == sessionID && x.GenreID == genreID && x.TicketPrice == toBeConverted);
            ViewBag.Seats = seats;
            if (query == null)
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
                    _saleSeatRep.Add(new SaleSeat { SaleID = toBeAdded.ID, SeatID = result.ID });
                    _sRep.Update(result);
                }


                SaleResvervationTicketVM srtvm = new SaleResvervationTicketVM()
                {


                    MovieName = toBeAdded.Movie.MovieName,
                    TicketPrice = Convert.ToDecimal(ticketPrice),
                    SalonID = saloonID,
                    SaleNo = toBeAdded.SaleNo,
                    TicketDate = (_sesRep.FirstOrDefault(x => x.ID == sessionID)).Time


                };


                return View(srtvm);

            }
            else
            {
                SaleResvervationTicketVM svtvm = new SaleResvervationTicketVM()
                {


                    MovieName = query.Movie.MovieName,
                    TicketPrice = Convert.ToDecimal(ticketPrice),
                    SalonID = saloonID,
                    SaleNo = query.SaleNo,
                    TicketDate = (_sesRep.FirstOrDefault(x => x.ID == sessionID)).Time


                };


                return View(svtvm);
            }



        }

        [HttpPost]
        public ActionResult ConfirmSale(int movieID, int saloonID, int sessionID, int genreID, string ticketPrice, string seats, CheckoutVM cvm)
        {
            bool result;
            decimal toBeConvertedPrice = Convert.ToDecimal(ticketPrice);
            cvm.Payment.TicketPrice = toBeConvertedPrice;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44391/api/");
                Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("Payment/ReceivePayment", cvm.Payment);

                HttpResponseMessage sonuc;

                try
                {
                    sonuc = postTask.Result;
                }
                catch (Exception)
                {
                    TempData["connectionDenial"] = "Banka bağlantıyı reddetti";
                    return RedirectToAction("Index", "Home");
                }

                if (sonuc.IsSuccessStatusCode)
                {
                    result = true;
                }
                else result = false;


                if (result)
                {
                    
                    ViewBag.Seats = seats;
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
                            Type = ENTITIES.Enums.PaymentType.CreditCard,
                            SaleType = ENTITIES.Enums.SaleType.Sale,
                            TicketPrice = toBeConvertedPrice
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
                            Seat find = _sRep.FirstOrDefault(x => x.SaloonID == saloonID && x.SessionID == sessionID && x.Character == item.Character && x.Number == item.Number);
                            _saleSeatRep.Add(new SaleSeat { SaleID = toBeAdded.ID, SeatID = find.ID });
                            find.SeatActive = true;
                            _sRep.Update(find);
                        }

                        TempData["paymentSuccess"] = "Bilet satin alma isleminiz basariyla gerceklesmistir. Bizi tercih ettiginiz icin tesekkür ederiz";

                    SaleResvervationTicketVM srvm = new SaleResvervationTicketVM()
                    {
                        MovieName = toBeAdded.Movie.MovieName,
                        TicketPrice = toBeConvertedPrice,
                        SalonID = saloonID,
                        SaleNo = toBeAdded.SaleNo,
                        TicketDate = (_sesRep.FirstOrDefault(x => x.ID == sessionID)).Time
                    };

                    return View(srvm);


                }
                
                TempData["paymentFailed"] = "Bilet alma isleminizde bir sorun olustu lutfen daha sonra tekrar deneyiniz.";
                return RedirectToAction("Index", "Home");








            }
        }
    }
}

