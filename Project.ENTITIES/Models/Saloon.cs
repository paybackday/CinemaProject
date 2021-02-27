using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Saloon:BaseEntity
    {
        public int SaloonNo { get; set; }
        public int Capacity { 
            get 
            {
                return Seats.Count();
            } 
        }

        public Saloon()
        {
            Seats = new List<Seat>();

            for (char j = 'A'; j < 'I'; j++)
            {
                for (int k = 1; k <= 14; k++)
                {
                    Seat seat = new Seat();
                    seat.SeatActive = false;
                    seat.SaloonID = this.ID;
                    seat.Character = Convert.ToString(j);
                    seat.Number = k;
                    Seats.Add(seat);
                }
            }
        }
       

        // Relational Properties

        public virtual List<MovieSessionSaloon> MovieSessionSaloons { get; set; }

        public virtual List<Seat> Seats { get; set; }


    }
    
}
