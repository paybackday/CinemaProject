using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class MovieActor:BaseEntity
    {
        public int MovieID { get; set; }
        public int ActorID { get; set; }

        // Relational Properties 

        public virtual Movie Movie { get; set; }
        public virtual Actor Actor{ get; set; }

    }
}
