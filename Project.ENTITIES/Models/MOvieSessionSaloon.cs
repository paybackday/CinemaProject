using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class MovieSessionSaloon:BaseEntity
    {
        public int MovieID { get; set; }
        public int SessionID { get; set; }
        public int SaloonID { get; set; }

        // Relational Properties

        public virtual Movie Movie { get; set; }
        public virtual Session Session { get; set; }
        public virtual Saloon Saloon{ get; set; }

    }
}
