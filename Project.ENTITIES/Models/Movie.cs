using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Movie:BaseEntity
    {
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string MovieYear { get; set; }
        public int? GenreID { get; set; }

        // Relational Properties

        public virtual Genre Genre { get; set; }
        public virtual List<MovieActor> MovieActors { get; set; }


    }
}
