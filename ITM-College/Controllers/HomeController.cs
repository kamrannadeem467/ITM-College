using System.Diagnostics;
using ITM_College.Areas.Identity.Data;
using ITM_College.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITM_College.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult Departments()
        {
            return View();
        }
        // Faculties list by Department
        public IActionResult Faculties(Guid departmentId)
        {
            var faculties = _context.Faculties
                            .Where(f => f.DepartmentId == departmentId)
                            .ToList();
            //var faculties = _context.Faculties.ToList();
            if (!faculties.Any())
            {
                TempData["msg"] = "No faculties found for this departments!";
            }
            return View(faculties);
        }
        public IActionResult Facilities()
        {
            return View();
        }
        public IActionResult AdmissionForm()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Feedback()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
