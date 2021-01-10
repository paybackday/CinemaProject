using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class UserProfile : BaseEntity
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez.")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş geçilemez.")]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "Gelir alanı boş geçilemez.")]
        public decimal Sallary { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }

        [Required(ErrorMessage = "Meslek alanı boş geçilemez.")]
        public string Job { get; set; }




        // Relational Properties 

        public virtual AppUser AppUser { get; set; }
    }
}
