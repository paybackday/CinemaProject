using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.WEBUI.Models.VMClasses
{
    public class PaymentVM
    {
        [Required(ErrorMessage ="Kart uzerindeki adi giriniz")]
        public string CardUserName { get; set; }
        [Required(ErrorMessage = "Kart guvenlik kodunu giriniz")]
        public string SecurityNumber { get; set; }
        [Required(ErrorMessage = "Kart numaranizi giriniz")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Kart uzerindeki ayi giriniz")]
        public int CardExpiryMonth { get; set; }
        [Required(ErrorMessage = "Kart uzerindeki yili giriniz")]
        public int CardExpiryYear { get; set; }
        public decimal TicketPrice { get; set; }
    }
}