using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Date { get; set; }
        public string Genero { get; set; }

        public List<Tarjeta> Tarjetas { get; set; }
        public List<Vehiculo> Vehiculos { get; set; }
    }
}
