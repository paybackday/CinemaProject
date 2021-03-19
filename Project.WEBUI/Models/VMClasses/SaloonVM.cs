using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.Models.VMClasses
{
    public class SaloonVM
    {
        public Saloon    Saloon  { get; set; }
        public List<Saloon> Saloons { get; set; }
        
    }
}