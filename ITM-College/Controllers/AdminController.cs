using ITM_College.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITM_College.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);   // Db me add karna
                _context.SaveChanges();                // Save karna
                return RedirectToAction("Dapartment", "Admin");      // Index page par redirect
            }

            return View(department);  // agar validation fail ho to form wapas dikhana
        }

        public IActionResult Dapartment()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }
    }
}
