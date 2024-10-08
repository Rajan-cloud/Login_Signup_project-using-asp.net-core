using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Rajan_Project.Migrations;
using Rajan_Project.Models;

namespace Rajan_Project.Controllers
{
    
    public class RegistrationController : Controller
    {
        private readonly DatabaseContext _context;
        public RegistrationController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AddEmployee(int id)
        {
            Employee_Reg em = new Employee_Reg();
            ViewBag.btn = "Register";
            if (id > 0)
            {
                var data = (from a in _context.Employee_Regs where a.Emp_id == id select a).ToList();
                em.Emp_id = data[0].Emp_id;
                em.Name = data[0].Name;
                em.Age = data[0].Age;
                em.Gender = data[0].Gender;
                em.Email = data[0].Email;
                em.Password = data[0].Password;
                em.Department = data[0].Department;
                em.City = data[0].City;
                ViewBag.btn = "Update";
            }
            return View(em);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee_Reg Emp_regs)
        {
            if(ModelState.IsValid)
            {
              
                await _context.AddAsync(Emp_regs);
                await _context.SaveChangesAsync();
                return RedirectToAction("ShowData");
            }
            else
            {
                ViewBag.msg = "Please Fill all Field";
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ShowData()
        {
            var data =  await _context.Employee_Regs.ToListAsync();
            return View(data);
        }

       
        public IActionResult Delete(int id)
        {
            var data = _context.Employee_Regs.FirstOrDefault(m => m.Emp_id == id);
            if(data!=null)
            {
                _context.Employee_Regs.Remove(data);
            }
             _context.SaveChanges();
            return RedirectToAction("ShowData");

        }
    }
}
