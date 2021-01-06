using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Seat:BaseEntity
    {
        public string SeatName { get; set; }
        public bool Active { get; set; }
        public ushort SeatAmount { get; set; }

    }
}
