using Microsoft.AspNetCore.Identity;

namespace WebKillaDeco.Models
{
    public class Rol : IdentityRole<int>
    {
        public Rol() : base()
        {

        }

        public Rol(String rolName) : base(rolName)
        {

        }

        //[Display(Name = Alias.RolName)]
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }
    }
}
