using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Rajan_Project.Models;
using System.Security.Claims;

namespace Rajan_Project.Controllers
{
    public class LoginController1 : Controller
    {
        private readonly DatabaseContext _context;
        public LoginController1(DatabaseContext context)
        {
                _context=context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginClass emp_log)
        {
            if(ModelState.IsValid)
            {
                var data = _context.Employee_Regs.Where(e => e.Name == emp_log.Name).SingleOrDefault();
                if(data!=null)
                {
                    bool isvalid = (data.Name == emp_log.Name && data.Password == emp_log.Password);
                    if(isvalid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name,emp_log.Name)},
                           CookieAuthenticationDefaults.AuthenticationScheme
                            );
                        var principle = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                        HttpContext.Session.SetString("Name", emp_log.Name);
                        return RedirectToAction("ShowData","Registration");
                    }
                    else
                    {
                        TempData["error message"] = "Invailid User name and Password";
                        return View(emp_log);
                    }
                }
                else
                {
                    TempData["error message"] = "Username not found";
                    return View(emp_log);
                }
            }
            else
            {
                return View(emp_log);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "LoginController1");
        }

        [HttpGet]
        public IActionResult Login_data()
        {
            var Id = HttpContext.Session.GetInt32("Idd");
            var data = (from a in _context.Employee_Regs where a.Emp_id == Id select a
                      );
            return View(data);
        }
    }
}
