using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.Models.VMClasses
{
    public class SaleVM
    {
        public Sale Sale { get; set; }
        public List<Sale> Sales { get; set; }
        public List<SaleSeat> SaleSeats { get; set; }
    }
}