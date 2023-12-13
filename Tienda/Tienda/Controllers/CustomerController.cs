using DataLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tienda.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TiendaContext _dbContext;
        public CustomerController(TiendaContext _db)
        {
            _dbContext = _db;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Customers.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            return View();
        }

        //Get Edit
        [HttpGet]
        [NonAction]
        public IActionResult Edit(int id)
        {
            Customer cust = _dbContext.Customers.Single(x => x.CustomerID == id);
            if (cust == null)
            {
                //return HttpNotFound();
                return NotFound();
            }

            return View("Edit", cust);
        }

        //Post Edit
        [HttpPost]
        public IActionResult Edit(Customer cust)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(cust).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }

            return View(cust);
        }

        //Get Details
        [NonAction]
        public IActionResult Details(int id)
        {
            Customer cust = _dbContext.Customers.Find(id);
            if (cust == null)
            {
                return NotFound();// HttpNotFound();
            }
            return View(cust);
        }

        //Get Delete
        [NonAction]
        public IActionResult Delete(int id)
        {
            Customer cust = _dbContext.Customers.Find(id);
            if (cust == null)
            {
                return NotFound();
            }
            return View(cust);

        }

        //Post Delete Confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Customer cust = _dbContext.Customers.Find(id);
            _dbContext.Customers.Remove(cust);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
