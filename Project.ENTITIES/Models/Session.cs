using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Session : BaseEntity
    {
        [Required(ErrorMessage = "Seans tarihi veya saati boş geçilemez")]
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
        public virtual List<Seat> Seats { get; set; }
        public virtual List<Sale> Sales { get; set; }


    }
}
