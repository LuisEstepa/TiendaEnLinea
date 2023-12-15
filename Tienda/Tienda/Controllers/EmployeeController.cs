using DataLayer;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tienda.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly TiendaContext _dbContext;
        public EmployeeController(TiendaContext _db) 
        { 
            _dbContext = _db;
        } 
        public IActionResult Index()
        {
            return View(_dbContext.AdminEmployee.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AdminEmployee emp)
        {
            if (ModelState.IsValid)
            {
                _dbContext.AdminEmployee.Add(emp);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        //Get Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            AdminEmployee emp = _dbContext.AdminEmployee.Single(x => x.EmpID == id);
            if (emp == null)
            {
                return NotFound();
            }
            //ViewBag.RoleID = new SelectList(_dbContext.Roles, "RoleID", "RoleName", emp.RoleID);
            return View("Edit", emp);
        }

        //Post Edit
        [HttpPost]
        public IActionResult Edit(AdminEmployee emp)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(emp).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.RoleID = new SelectList(_dbContext.Roles, "RoleID", "RoleName", emp.RoleID);
            return View(emp);
        }

        //Get Details
        public IActionResult Details(int id)
        {
            AdminEmployee emp = _dbContext.AdminEmployee.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        //Get Delete
        public IActionResult Delete(int id)
        {
            AdminEmployee emp = _dbContext.AdminEmployee.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);

        }

        //Post Delete Confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            AdminEmployee admin_Employee = _dbContext.AdminEmployee.Find(id);
            _dbContext.AdminEmployee.Remove(admin_Employee);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
