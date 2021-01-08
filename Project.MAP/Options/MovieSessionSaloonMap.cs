using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class MovieSessionSaloonMap:BaseMap<MovieSessionSaloon>
    {
        public MovieSessionSaloonMap()
        {
            Ignore(x => x.ID);
            HasKey(x => new
            {
                x.MovieID,
                x.SessionID,
                x.SaloonID


            });
        }
    }
}
