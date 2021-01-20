using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.ENTITIES.Enums;

namespace Project.ENTITIES.Models
{
    public class Employee : BaseEntity
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş geçilemez.")]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "TC alanı boş geçilemez.")]
        public string TCNO { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal Sallary { get; set; }
      


        // Relational Properties

        public virtual List<Sale> Sales { get; set; }
        public virtual List<Reservation> Reservations { get; set; }

    }
}
