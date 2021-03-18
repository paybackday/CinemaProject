using PagedList;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.WEBUI.Models.VMClasses
{
    public class MovieVM
    {
        
        public string DateControl { get; set; }
        public Movie Movie { get; set; }
        public List<MovieSessionSaloon> MovieSessionSaloons { get; set; }
        public List<Saloon> Saloons { get; set; }
        public List<MovieActor> MovieActors { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }
        public Director Director { get; set; }
        public List<Director> Directors { get; set; }

        public IPagedList<Movie> PagedMovies { get; set; }
    }
}