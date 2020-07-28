using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public String Tipo { get; set; }
        public String Color { get; set; }
        public String Descripcion { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public User User { get; set; }
    }
}
