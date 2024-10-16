using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Rajan_Project.Models;
using Rajan_Project.Models.Account;
using Rajan_Project.Models.ViewModel;
using System.Security.Claims;

namespace Rajan_Project.Controllers.Account_Details
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext context;

        public AccountController(DatabaseContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignUpLogin model)
        {
            if(ModelState.IsValid)
            {
                var data = new User()
                {
                    Username = model.Username,
                    Email=model.Email,
                    Password=model.Password,
                    Mobile=model.Mobile,
                    IsActive=model.IsActive,
                };
                context.Users.Add(data);
                context.SaveChanges();
                TempData["successMessage"] = "You are eligble be login";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["errorMessage"] = "Empty form can not be submitted";
                return View(model);
            }
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginSignUpViewModel model)
        {
            if(ModelState.IsValid)
            {
                var data = context.Users.Where(e => e.Username == model.Username).SingleOrDefault();
                if(data!=null)
                {
                    bool isvailid = (data.Username == model.Username && data.Password==model.Password);
                    if (isvailid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name,model.Username)},
                           CookieAuthenticationDefaults.AuthenticationScheme
                            );
                        var principle = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                        HttpContext.Session.SetString("Name", model.Username);
                        return RedirectToAction("User_data", "Account");
                        //return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["errormessage"] = "Invailid User name and Password";
                        return View(model);
                    }
                }
                else
                {
                    TempData["error message"] = "User Name not found";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storecookies = Request.Cookies.Keys;
            foreach ( var cookies in storecookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult User_data()
        {
           var data= context.Users.ToList();
            return View(data);
        }
    }
}
