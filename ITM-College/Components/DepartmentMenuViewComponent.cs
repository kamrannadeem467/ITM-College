using ITM_College.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ITM_College.Components
{
    public class DepartmentMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public DepartmentMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Database se Departments fetch karo
            var departments = _context.Departments.ToList();
            return View(departments);
        }
    }
}
