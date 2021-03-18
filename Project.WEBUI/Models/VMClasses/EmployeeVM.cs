using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.Models.VMClasses
{
    public class EmployeeVM
    {
        public List<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
    }
}