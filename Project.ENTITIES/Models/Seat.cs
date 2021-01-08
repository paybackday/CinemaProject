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
        public ushort Number { get; set; }
        public char Character { get; set; }


        // Relational Properties
        public virtual Saloon Saloon { get; set; }
    
        public virtual List<SaleSeat> SaleSeats { get; set; }


    }
}
