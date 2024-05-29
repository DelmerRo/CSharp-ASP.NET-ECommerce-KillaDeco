using System;
using System.Collections.Generic;
using System.Linq;
namespace WebKillaDeco.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
