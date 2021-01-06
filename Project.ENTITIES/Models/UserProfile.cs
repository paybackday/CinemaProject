﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class UserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public decimal Sallary { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Job { get; set; }




        // Relational Properties 

        public virtual AppUser AppUser { get; set; }
    }
}
