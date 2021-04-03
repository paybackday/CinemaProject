using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Seat : BaseEntity
    {
        public bool SeatActive { get; set; }
        public int SaloonID { get; set; }
        public int? SessionID { get; set; } 
        public int Number { get; set; } 
        public string Character { get; set; }


        // Relational Properties
        public virtual Saloon Saloon { get; set; }
        public virtual Session Session { get; set; }

        public virtual List<SaleSeat> SaleSeats { get; set; }


    }
}
