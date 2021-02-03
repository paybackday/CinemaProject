using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.Models.VMClasses
{
    //Seatlist == A grubu, B Grubu...
    public class SeatListVM
    {
        public int SaloonID { get; set; }
        public string Character { get; set; }
        public List<Seat> Seats { get; set; }
    }
}