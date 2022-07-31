using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using YMS.EfCoreTutorial.Contexts;
using YMS.EfCoreTutorial.Models;

namespace YMS.EfCoreTutorial.Controllers
{
    public class AuthController : Controller
    {
        private readonly YMSContext _context;

        public AuthController(YMSContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View(new UserLoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {


            if (ModelState.IsValid)
            {
                // Use Input.Email and Input.Password to authenticate the user
                // with your custom authentication logic.
                //
                // For demonstration purposes, the sample validates the user
                // on the email address maria.rodriguez@contoso.com with 
                // any password that passes model validation.


                /* 
                 
                 Appuser AppRole AppRoleGroup 
                 1       /Home/Create  Admin 
                         /Home/Update
                         /Home/Delete
                 */

                var user = _context.AppUsers.AsNoTracking().SingleOrDefault(x=>x.Username==model.Username && x.Password == model.Password);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }

                var role = _context.AppRoles.AsNoTracking().SingleOrDefault(x=>x.Id== user.RoleId);



                var claims = new List<Claim>
        {
            new Claim("Username", user.Username),
            new Claim(ClaimTypes.Role, role.Definition),
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {              
                    IsPersistent = model.RememberMe,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }


            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
