using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer;

namespace Tienda.Controllers
{
    public class ProfileController : Controller
    {
        private readonly TiendaContext _dbcontext;

        public ProfileController(TiendaContext _db)
        {
            _dbcontext = _db;
        }
        // GET: Profile
        public IActionResult Index()
        {
            return View(_dbcontext.AdminEmployee.Find(TemData.EmpID));
        }

        public IActionResult Edit(int id)
        {
            AdminEmployee emp = _dbcontext.AdminEmployee.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(AdminEmployee emp)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Entry(emp).State = EntityState.Modified;
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
