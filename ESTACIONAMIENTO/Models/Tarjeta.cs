using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.Models
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public String Nombre { get; set; }
        public String Numero { get; set; }
        public DateTime Date { get; set; }
        public String CV2 { get; set; }

        public User User { get; set; }
    }
}
