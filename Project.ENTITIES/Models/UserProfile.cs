using Project.ENTITIES.Enums;
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


        public decimal? Sallary { get; set; }
        [Required(ErrorMessage ="Cinsiyet seçimi yapınız")]
        public Gender Gender { get; set; }
        public string City { get; set; }

      
        public string Job { get; set; }
       




        // Relational Properties 

        public virtual AppUser AppUser { get; set; }
    }
}
