using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public  class SaleSeat:BaseEntity
    {
        public int SaleID { get; set; }
        public int SeatID { get; set; }


        // Relational Properties

        public virtual Sale Sale { get; set; }
        public virtual Seat Seat{ get; set; }
    }
}
