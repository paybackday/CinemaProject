using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.Models.VMClasses
{
    public class MovieSessionSaloonVM
    {
        public Movie   Movie { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Saloon> Saloons { get; set; }
        public List<Session> Sessions { get; set; }
        public Saloon Saloon { get; set; }
        public Session Session { get; set; }
        public MovieSessionSaloon  MovieSessionSaloon { get; set; }
        public List<MovieSessionSaloon> MovieSessionSaloons { get; set; }

    }
}