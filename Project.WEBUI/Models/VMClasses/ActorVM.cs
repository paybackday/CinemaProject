using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.Models.VMClasses
{
    public class ActorVM
    {
        public Actor Actor  { get; set; }
        public List<Actor> Actors { get; set; }
        public MovieActor MovieActor  { get; set; }
        public List<MovieActor> MovieActors { get; set; }
        public Movie Movie { get; set; }
        public List<Movie> Movies { get; set; }
    }
}