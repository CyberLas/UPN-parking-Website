using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.Models
{
    public class Estacionamiento
    {
        public int Id { get; set; }
        public String TipoVehiculo { get; set; }
        public int Pago { get; set; }
        public String Latitud { get; set; }
        public String Longitud { get; set; }
        public bool Dia { get; set; }
    }
}
