using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.Models.VMClasses
{
    
    public class SeatVM
    {
        public List<Seat> Seats { get; set; }

        //public List<SeatListVM> SeatLists { get; set; }
        public decimal Price { get; set; }
    }

    
}