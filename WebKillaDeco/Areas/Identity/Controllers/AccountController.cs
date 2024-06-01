using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.Areas.Identity.ViewModels;
using WebKillaDeco.Models;

namespace WebKillaDeco.Areas.Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly KillaDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Rol> _rolManager;
        //private const string passDefault = "Password1!";
        private const string domainAdministrator = "@killa.com.ar";

        public AccountController(KillaDbContext context, UserManager<User> userManager, SignInManager<User> signinManager, RoleManager<Rol> rolManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signinManager;
            _rolManager = rolManager;
        }

        [HttpGet]
        public IActionResult AccesoDenegado()
        {
            return View();
        }

        public ActionResult LogIn(string returnurl)
        {
            TempData["returnUrl"] = returnurl;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(LogIn logInViewModel)
        {
            string? returnUrl = TempData["returnUrl"] as string;

            if (ModelState.IsValid)
            {
                var user = _context.Admins.FirstOrDefault(u => u.Email == logInViewModel.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Inicio de sesión inválido");
                }
                else
                {
                    var resultadoSignIn = await _signInManager.PasswordSignInAsync(user, logInViewModel.Password, logInViewModel.Remember, false);
                    if (resultadoSignIn.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Inicio de sesión inválido");
                    }
                }
            }
            return View(logInViewModel);
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser(RegisterUserViewModel userViewModel)
        {
            //Hago con model lo que necesito.

            if (ModelState.IsValid)
            {
                User newUser = new();
                newUser.Dni = userViewModel.Dni;
                newUser.Cuil = userViewModel.Cuil;
                newUser.Name = userViewModel.Name;
                newUser.LastName = userViewModel.LastName;
                newUser.Phone = userViewModel.Phone;
                newUser.Email = userViewModel.Email+ domainAdministrator;
                newUser.BirthDate = userViewModel.BirthDate;
                newUser.DateAdded = DateTime.Now;

                var createResult = await _userManager.CreateAsync(newUser, userViewModel.Password);

                if (createResult.Succeeded)
                {

                    if (!_rolManager.Roles.Any())
                    {
                        await CreateRoleBase();
                    }

                    var result = await _userManager.AddToRoleAsync(newUser, "Admin");

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Users", new { id = newUser.Id });
                    }
                }

                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(userViewModel);
        }

        private async Task CreateRoleBase()
        {
            List<string> roles = new() { "Admin", "Employee", "Client", "Supplier" };

            if (!_context.Roles.Any())
            {
                foreach (string rol in roles)
                {
                    await CreateRole(rol);
                }
            }
        }

        private async Task CreateRole(string roleName)
        {
            if (!await _rolManager.RoleExistsAsync(roleName))
            {
                await _rolManager.CreateAsync(new Rol(roleName));
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
