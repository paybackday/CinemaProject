using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Reservation : BaseEntity
    {
        public int? AppUserID { get; set; }
        public int MovieID { get; set; }
        public int SessionID { get; set; }
        public int GenreID { get; set; }
        public int? EmployeeID { get; set; }
        public string ReservationNO { get; set; }

        public Reservation()
        {
            ReservationNO = Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-"));
        }
        //Relational Properties

        public virtual AppUser AppUser { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Session Session { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual List<ReservationSeat> ReservationSeats { get; set; }


    }
}
