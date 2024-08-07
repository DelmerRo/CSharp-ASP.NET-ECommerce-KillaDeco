﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NuGet.Packaging.Signing;
using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.Areas.Identity.ViewModels;
using WebKillaDeco.Helpers;
using WebKillaDeco.Models;

namespace WebKillaDeco.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly KillaDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Rol> _rolManager;
        private const string domainAdministrator = "@killa.com.ar";

        public AccountController(KillaDbContext context, UserManager<User> userManager, SignInManager<User> signinManager, RoleManager<Rol> rolManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signinManager;
            _rolManager = rolManager;
        }
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult AccesoDenegado()
        {
            return View();
        }

        public ActionResult Login(string returnurl)
        {
            TempData["returnUrl"] = returnurl;
                if (!ModelState.IsValid)
                {
                    return View();
                }
                return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Login logInViewModel)
        {
            string returnUrl = TempData["returnUrl"]?.ToString() ?? string.Empty;

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(logInViewModel.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Inicio de sesión inválido");
                }
                else
                {
                    var resultadoSignIn = await _signInManager.PasswordSignInAsync(user, logInViewModel.Password, logInViewModel.Remember, false);
                    if (resultadoSignIn.Succeeded)
                    {
                        return await RedirectByRole(user, returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Inicio de sesión inválido");
                    }
                }
            }
            return View(logInViewModel);
        }

        private async Task<IActionResult> RedirectByRole(User user, string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains(Config.RolClient))
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else if (roles.Contains(Config.RolEmployee))
            {
                return RedirectToAction("Index", "Home", new { area = "Identity" });
            }
            else if (roles.Contains(Config.RolAdmin))
            {
                return RedirectToAction("Index", "Home", new { area = "Identity" });
            }

            return Redirect("/");
        }


        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPassword resetPasswordViewModel)
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgotPassword forgotPasswordViewModel)
        {
            return View();
        }


            public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel userViewModel)
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
