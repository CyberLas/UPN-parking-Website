using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdEstacionamiento { get; set; }
        public String Fecha { get; set; }
        public int IdTarjeta { get; set; }
        public int NHoras { get; set; }
    }
}
