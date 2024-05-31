namespace WebKillaDeco.Areas.Identity.ViewModels
{
    public class RegisterUserViewModel
    {
        public string Dni { get; set; }
        public string Cuil { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string ConfirmacionPassword { get; set; }
    }
}
