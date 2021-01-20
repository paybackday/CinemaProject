using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Session : BaseEntity
    {
        public DateTime Time { get; set; }
        public bool SessionActive { get; set; }

        public decimal Price { get; set; }



        // Relational Properties

        public virtual List<MovieSessionSaloon> MovieSessionSaloons { get; set; }
        public virtual List<Sale> Sales { get; set; }
        public virtual List<Reservation> Reservations { get; set; }


    }
}
