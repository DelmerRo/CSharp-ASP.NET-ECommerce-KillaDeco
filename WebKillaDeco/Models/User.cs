using Microsoft.AspNetCore.Identity;

namespace WebKillaDeco.Models
{
    public class User : IdentityUser<int>
    {
        public string Dni { get; set; }
        public string Cuil { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateAdded { get; set; }

        // Relación uno a uno con Address
        public Address? Address { get; set; }

        public string? FullName => $"{LastName?.ToUpper()}, {Name}";
    }
}
