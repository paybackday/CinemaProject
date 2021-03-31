using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.Models.VMClasses
{
    public class SaleResvervationTicketVM
    {
        public string Character { get; set; }
        public DateTime TicketDate { get; set; }
        public string Number { get; set; }
        public decimal TicketPrice { get; set; }
        public string   MovieName { get; set; }
        public string  SaleNo { get; set; }
        public int SalonID { get; set; }
    }
}