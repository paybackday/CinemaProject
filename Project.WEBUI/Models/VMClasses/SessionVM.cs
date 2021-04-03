using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.Models.VMClasses
{
    public class SessionVM
    {
        public Session Session { get; set; }
        public List<Session> Sessions { get; set; }
        public MovieSessionSaloon MovieSessionSaloon { get; set; }
        public List<MovieSessionSaloon>  MovieSessionSaloons { get; set; }
    }
}