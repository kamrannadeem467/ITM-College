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
            var courses = _context.Courses.ToList();
            if(courses == null)
            {
                return NotFound();
            }
            return View(courses);
        }
        public IActionResult CourseDetail(Guid id)
        {
            var courses = _context.Courses.FirstOrDefault(c => c.CourseID == id);
            if (courses == null)
            {
                // Option 1: 404 Not Found return karein
                return NotFound();

                // Option 2: Error page pe redirect karein
                // return RedirectToAction("Error", "Home");
            }
            return View(courses);
        }
        [HttpGet]
        public IActionResult Departments()
        {
            var departments = _context.Departments.Include(d => d.Faculties).ToList();
            if (departments == null)
            {
                return NotFound();
            }
            return View(departments);
        }

        [HttpGet("Departments/{id}")]
        public IActionResult Departments(Guid? id)
        {
            var departments = _context.Departments
                .Include(d => d.Faculties)
                .ToList();

            if (id.HasValue)
            {
                departments = departments.Where(d => d.Id == id.Value).ToList();
            }

            return View(departments);
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
            var facilities = _context.Facilities.ToList();
            return View(facilities);
        }
        public IActionResult FacilityDetail(Guid id)
        {
            var facilities = _context.Facilities.FirstOrDefault(f => f.FacilityId == id);
            if (facilities == null)
            {
                return NotFound();
            }
            return View(facilities);
        }
        public IActionResult AdmissionForm()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveContact(Contact model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Validation failed. Please fill all fields correctly." });
            }

            // **Duplicate Email Check**
            bool emailExists = _context.Contacts.Any(c => c.Email == model.Email);
            if (emailExists)
            {
                return Json(new { success = false, message = "This email has already submitted a message!" });
            }

            _context.Contacts.Add(model);
            _context.SaveChanges();

            return Json(new { success = true, message = "Your message has been sent successfully!" });
        }

        // (Optional) **Live Email Check**
        [HttpGet]
        public JsonResult CheckEmail(string email)
        {
            bool exists = _context.Contacts.Any(c => c.Email == email);
            return Json(exists);
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
