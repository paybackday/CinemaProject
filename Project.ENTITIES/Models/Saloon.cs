using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Saloon:BaseEntity
    {
        public Seat Seat { get; set; }

        public Saloon()
        {
            Seat=new Seat();
        }

        // Relational Properties

        public virtual List<MovieSessionSaloon> MovieSessionSaloons { get; set; }

    }
    
}
