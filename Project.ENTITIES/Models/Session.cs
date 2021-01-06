using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Session : BaseEntity
    {
       public DateTime Time { get; set; }

       public decimal Price { get; set; }
       
        


        // Relational Properties

        public virtual List<MovieSessionSaloon> MovieSessionSaloons { get; set; }

    }
}
