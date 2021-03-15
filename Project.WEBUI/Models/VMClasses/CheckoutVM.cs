using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.Models.VMClasses
{
    public class CheckoutVM
    {
        public Movie Movie { get; set; }
        public Session Session { get; set; }
        public Saloon Saloon { get; set; }
        public Sale Sale { get; set; }
        public List<Seat> SelectedSeats { get; set; }
        public PaymentVM Payment { get; set; }
        public int StudentCount { get; set; }
    }
}