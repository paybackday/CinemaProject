using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.Models.VMClasses
{
    public class MovieVM
    {
        public Movie Movie { get; set; }
        public List<MovieActor> MovieActors { get; set; }
        public List<Movie> Movies { get; set; }
    }
}