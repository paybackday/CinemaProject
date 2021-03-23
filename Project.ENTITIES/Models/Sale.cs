using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.ENTITIES.Enums;

namespace Project.ENTITIES.Models
{
    public class Sale : BaseEntity //Think Ticket
    {

        public int? AppUserID { get; set; }
        public int MovieID { get; set; }
        public int SessionID { get; set; }
       
        public int GenreID { get; set; }
        public int? EmployeeID { get; set; }
        public PaymentType Type { get; set; }
        public SaleType SaleType { get; set; }
        public string SaleNo { get; set; }
        public decimal? TicketPrice { get; set; }

        public void CalculateDiscount() { //VIP indirim hesaplamasi
            if (AppUser.Role==UserRole.Vip)
            {
                Session.Price = (Session.Price - (Session.Price * 0.5m));
            }
        
        }


     

        public Sale()
        {
            SaleNo = Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-")); // 8 Haneli benzersiz Alfa Şifresi Oluşturulacak.
        }

        // Relational Properties

        public virtual AppUser AppUser { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Session Session { get; set; }
        public virtual Genre Genre{ get; set; }
        public virtual List<SaleSeat> SaleSeats { get; set; }
        public virtual Employee Employee { get; set; }

        





    }
}
