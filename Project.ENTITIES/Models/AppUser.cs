using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Project.ENTITIES.Enums;

namespace Project.ENTITIES.Models
{
    public class AppUser:BaseEntity
    {
        public UserRole Role { get; set; }
        public Guid ActivationCode { get; set; }
        public bool Active { get; set; }
        public string ImagePath { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public short Credit { get; set; } // Film Başına gelen Kredi Properties
        public decimal Balance { get; set; } // Havale ile gelen Bakiye

        public AppUser()
        {
            Role = UserRole.Member;
            ActivationCode=Guid.NewGuid();
        }

        // Relational Properties 
        public virtual UserProfile UserProfile { get; set; }
    }
}
