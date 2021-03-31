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


        public Saloon()
        {
            Seats = new List<Seat>();


        }


        // Relational Properties

        public virtual List<MovieSessionSaloon> MovieSessionSaloons { get; set; }

        public virtual List<Seat> Seats { get; set; }



    }
    
}
