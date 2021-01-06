using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Saloon:BaseEntity
    {
        public ushort SaloonNo { get; set; }
        public ushort Capacity { get; set; }
       

        // Relational Properties

        public virtual List<MovieSessionSaloon> MovieSessionSaloons { get; set; }
        public virtual List<Seat> Seats { get; set; }


    }
    
}
