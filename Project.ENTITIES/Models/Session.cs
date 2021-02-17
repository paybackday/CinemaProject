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

        protected decimal _price;
        public decimal Price { 
            get
            {
                if (Time.DayOfWeek == DayOfWeek.Thursday)
                {
                    return (_price - (_price * 0.5m)); //Persembe gunu halk gunu
                }

                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public bool IsSpecial { get; set; }



        // Relational Properties

        public virtual List<MovieSessionSaloon> MovieSessionSaloons { get; set; }
        public virtual List<Sale> Sales { get; set; }
        public virtual List<Reservation> Reservations { get; set; }


    }
}
