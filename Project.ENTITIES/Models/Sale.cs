using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.ENTITIES.Enums;

namespace Project.ENTITIES.Models
{
    public class Sale : BaseEntity
    {

        public int AppUserID { get; set; }
        public int MovieID { get; set; }
        // public int SeatID { get; set; }
        // public int SessionID { get; set; }

        //public int GenreID { get; set; }
        public int? EmployeeID { get; set; }

        public PaymentType Type { get; set; }



        // Relational Properties




    }
}
