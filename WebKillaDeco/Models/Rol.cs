using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebKillaDeco.Helpers;

namespace WebKillaDeco.Models
{
    public class Rol : IdentityRole<int>
    {
        public Rol() : base()
        {

        }

        public Rol(string rolName) : base(rolName)
        {

        }

        [Display(Name = Alias.RolName)]
        public override string? Name // Aquí añadimos el símbolo '?' para indicar que la propiedad puede ser nula
        {
            get { return base.Name; }
            set { base.Name = value; }
        }
    }
}