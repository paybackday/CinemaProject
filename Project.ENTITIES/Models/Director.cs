using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Director:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Country { get; set; }

        //Relational Properties
        public virtual List<Movie> Movies { get; set; }
    }
}
