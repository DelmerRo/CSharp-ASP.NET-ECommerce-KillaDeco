using System;
using System.Collections.Generic;
using System.Linq;
namespace WebKillaDeco.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        // Claves foráneas para la relación uno a uno con User y Location
        public int? UserId { get; set; }
        public int? LocationId { get; set; }

        public string? Street { get; set; }
        public int Number { get; set; }
        public string? Tower { get; set; }
        public int Floor { get; set; }
        public string? Department { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        // Propiedades de navegación
        public User? User { get; set; }
        public Location? Location { get; set; }
    }
}
