using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Movie : BaseEntity
    {
  
        [Required(ErrorMessage = "Film isim alanı boş geçilemez.")]
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string MovieYear { get; set; }
        public int? GenreID { get; set; }
        public string MovieLength { get; set; }
        public string MovieImagePath  { get; set; }
        public int? DirectorID { get; set; }


        // Relational Properties

        public virtual Genre Genre { get; set; }
        public virtual List<MovieActor> MovieActors { get; set; }
        public virtual List<MovieSessionSaloon> MovieSessionSaloons { get; set; }
        public virtual List<Sale> Sales { get; set; }
        public virtual Director Director { get; set; }


    }
}
