using ExploreCalifornia.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(
            SignInManager<IdentityUser> signinManager,
            UserManager<IdentityUser> userManager)
        {
            this._signinManager = signinManager;
            this._userManager = userManager;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await this._signinManager.PasswordSignInAsync(
                login.EmailAddress, login.Password,
                login.RememberMe, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Login Error!");
                return View();
            }

            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }

        [HttpPost]
        public async Task<ActionResult> Logout(string returnUrl = null)
        {
            await this._signinManager.SignOutAsync();

            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }


        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registration)
        {
            if (!ModelState.IsValid)
                return View(registration);

            var newUser = new IdentityUser
            {
                Email = registration.EmailAddress,
                UserName = registration.EmailAddress,
            };

            var result = await this._userManager.CreateAsync(newUser, registration.Password);

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors.Select(x => x.Description))
                {
                    ModelState.AddModelError("", error);

                    return View();
                }
            }

            return RedirectToAction("Login");
        }
    }
}
