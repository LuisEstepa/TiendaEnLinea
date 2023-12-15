using DataLayer;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tienda.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly TiendaContext _dbcontext;

        public SupplierController(TiendaContext _db)
        {
            _dbcontext = _db;            
        }
        public IActionResult Index()
        {
            return View(_dbcontext.Suppliers.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier supp)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Suppliers.Add(supp);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            Supplier supp = _dbcontext.Suppliers.Single(x => x.SupplierID == id);
            if (supp == null)
            {
                return NotFound();
            }
            return View(supp);
        }

        [HttpPost]
        public IActionResult Edit(Supplier supp)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Entry(supp).State = EntityState.Modified;
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supp);
        }

        public IActionResult Details(int id)
        {
            Supplier supp = _dbcontext.Suppliers.Find(id);
            if (supp == null)
            {
                return NotFound();
            }
            return View(supp);
        }

        public IActionResult Delete(int id)
        {
            Supplier supp = _dbcontext.Suppliers.Find(id);
            if (supp == null)
            {
                return NotFound();
            }
            return View(supp);
        }

        //Post Delete Confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Supplier supp = _dbcontext.Suppliers.Find(id);
            _dbcontext.Suppliers.Remove(supp);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
