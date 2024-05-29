using Microsoft.AspNetCore.Identity;

namespace WebKillaDeco.Models
{
    public  class User: IdentityUser<int>
    {
        public string? Dni { get; set; }
        public string? Cuil { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime DateAdded { get; set; }
        public List<Address>? Addresses { get; set; }

        public string? FullName => $"{LastName.ToUpper()}, {Name}";
    }
}
