using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Project.ENTITIES.Enums;

namespace Project.ENTITIES.Models
{
    public class AppUser : BaseEntity
    {
        public UserRole Role { get; set; }
        public Guid ActivationCode { get; set; }
        public bool Active { get; set; }
        public string ImagePath { get; set; }
        public string Email { get; set; }
       

        [Required(ErrorMessage ="Şifre alanı boş geçilemez.")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Şifre tekrar alanı boş geçilemez.")]
        [Compare("Password", ErrorMessage = "Girilen şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
        public short Credit { get; set; } 
        public decimal Balance { get; set; }

        public AppUser()
        {
            Role = UserRole.Member;
            ActivationCode = Guid.NewGuid();
        }

        // Relational Properties 
      
        public virtual UserProfile UserProfile { get; set; }
        public virtual List<Sale> Sales { get; set; }
    }
}
