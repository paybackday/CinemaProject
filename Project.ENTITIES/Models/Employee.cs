using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.ENTITIES.Enums;

namespace Project.ENTITIES.Models
{
    public class Employee:BaseEntity
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCNO { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal Sallary { get; set; }
        

        // Relational Properties



    }
}
