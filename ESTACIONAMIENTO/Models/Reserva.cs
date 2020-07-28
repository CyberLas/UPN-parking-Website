using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int IdEstacionamiento { get; set; }
        public int IdUser { get; set; }
        public int NHora { get; set; }
        public DateTime Fecha { get; set; }
    }
}
