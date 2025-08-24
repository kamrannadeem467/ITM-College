using ITM_College.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITM_College.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Dashboard Methods
        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }

        //Departments Methods
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

        // GET: Department/Edit/5
        [HttpGet]
        public IActionResult EditDepartment(Guid id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                return RedirectToAction("Dapartment", "Admin"); // Index pe wapas
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult DeleteDepartment(Guid id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction("Dapartment", "Admin");
        }

        //Course Methods 

        // List All Courses
        public async Task<IActionResult> Course()
        {
            var courses = _context.Courses.Include(c => c.Department);
            return View(await courses.ToListAsync());
        }

        // GET: AddCourse
        public IActionResult AddCourse()
        {
            var departments = _context.Departments.ToList();
            ViewBag.departmentData = new SelectList(departments, "Id", "DepartmentName"); //model fields

            return View();
        }

        // POST: AddCourse
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCourse(Course course)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Course", "Admin");
        
        }

        // Edit Course
        public async Task<IActionResult> EditCourse(Guid id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();
            var departments = _context.Departments.ToList();
            ViewBag.departmentData = new SelectList(departments, "Id", "DepartmentName"); //model fields
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCourse(Guid id, Course course)
        {
                _context.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("Course", "Admin");
        }

        // Delete Course
        public IActionResult DeleteCourse(Guid id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("Course", "Admin");
        }


        //Faculties Methods 

        // List All Faculties
        public async Task<IActionResult> Faculty()
        {
            var faculties = _context.Faculties.Include(c => c.Department);
            return View(await faculties.ToListAsync());
        }

        // GET: AddFaculties
        public IActionResult AddFaculty()
        {
            var departments = _context.Departments.ToList();
            ViewBag.departmentData = new SelectList(departments, "Id", "DepartmentName"); //model fields

            return View();
        }

        // POST: AddFaculty
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFaculty(Faculty faculty)
        {
            _context.Add(faculty);
            await _context.SaveChangesAsync();
            return RedirectToAction("Faculty", "Admin");

        }

        // Edit Faculty
        public async Task<IActionResult> EditFaculty(Guid id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty == null) return NotFound();
            var departments = _context.Departments.ToList();
            ViewBag.departmentData = new SelectList(departments, "Id", "DepartmentName"); //model fields
            return View(faculty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFaculty(Guid id, Faculty faculty)
        {
            _context.Update(faculty);
            await _context.SaveChangesAsync();
            return RedirectToAction("Faculty", "Admin");
        }

        // Delete Faculties
        public IActionResult DeleteFaculty(Guid id)
        {
            var faculty = _context.Faculties.Find(id);
            if (faculty == null)
            {
                return NotFound();
            }
            _context.Faculties.Remove(faculty);
            _context.SaveChanges();
            return RedirectToAction("Faculty", "Admin");
        }

        //Facilities Methods 

        // List All Facilities
        public async Task<IActionResult> Facility()
        {
            var facilities = await _context.Facilities.ToListAsync();
            return View(facilities); // ✅ Facility list bhejna hoga
        }

        // GET: AddFaculties
        public IActionResult AddFacility()
        {
            return View();
        }

        // POST: AddFacility
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFacility(Facility facility)
        {
            _context.Add(facility);
            await _context.SaveChangesAsync();
            return RedirectToAction("Facility", "Admin");

        }

        // Edit Facility
        public async Task<IActionResult> EditFacility(Guid id)
        {
            var facility = await _context.Facilities.FindAsync(id);
            if (facility == null) return NotFound();
            return View(facility);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFacility(Guid id, Facility facility)
        {
            _context.Update(facility);
            await _context.SaveChangesAsync();
            return RedirectToAction("Facility", "Admin");
        }

        // Delete Facilities
        public IActionResult DeleteFacility(Guid id)
        {
            var facility = _context.Facilities.Find(id);
            if (facility == null)
            {
                return NotFound();
            }
            _context.Facilities.Remove(facility);
            _context.SaveChanges();
            return RedirectToAction("Facility", "Admin");
        }

        public IActionResult Contact()
        {
            var contacts = _context.Contacts.ToList();
            return View(contacts);
        }
        public IActionResult DeleteContact(Guid id)
        {
            var contacts = _context.Contacts.Find(id);
            if (contacts == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(contacts);
            _context.SaveChanges();
            return RedirectToAction("Contact", "Admin");
        }
    }
}
