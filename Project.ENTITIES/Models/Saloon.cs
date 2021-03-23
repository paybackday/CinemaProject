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
        public int Capacity
        {
            get
            {
                return Seats.Where(x=> x.SaloonID == this.ID).Count();
            }
            
        }

        //Seats.Count()

        public Saloon()
        {
            Seats = new List<Seat>();//TODO:Bakılacak


        }


        // Relational Properties

        public virtual List<MovieSessionSaloon> MovieSessionSaloons { get; set; }

        public virtual List<Seat> Seats { get; set; }



    }
    
}
