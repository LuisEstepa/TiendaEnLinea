using DataLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Tienda.Controllers
{
    public class ProductController : Controller
    {
        private readonly TiendaContext _dbContext;

        public ProductController(TiendaContext _db)
        {
            _dbContext = _db;            
        }

        public IActionResult Index()
        {
            return View(_dbContext.Products.ToList());
        }

        public IActionResult Create()
        {
            GetViewBagData();
            return View();
        }
        public void GetViewBagData()
        {
            ViewBag.SupplierID = new SelectList(_dbContext.Suppliers, "SupplierID", "CompanyName");
            ViewBag.CategoryID = new SelectList(_dbContext.Categories, "CategoryID", "Name");
            ViewBag.SubCategoryID = new SelectList(_dbContext.SubCategories, "SubCategoryID", "Name");
        }

        [HttpPost]
        public IActionResult Create(Product prod)
        {
            if (ModelState.IsValid)
            {
                //foreach (var file in Picture1)
                //{
                //    if (file != null || file.ContentLength > 0)
                //    {
                //        string ext = System.IO.Path.GetExtension(file.FileName);
                //        if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                //        {
                //            file.SaveAs(Path.Combine(Server.MapPath("/Content/Images/large"), Guid.NewGuid() + Path.GetExtension(file.FileName)));

                //            var medImg= Images.ResizeImage(Image.FromFile(file.FileName), 250, 300);
                //            medImg.Save(Path.Combine(Server.MapPath("/Content/Images/medium"), Guid.NewGuid() + Path.GetExtension(file.FileName)));


                //            var smImg = Images.ResizeImage(Image.FromFile(file.FileName), 45, 55);
                //            smImg.Save(Path.Combine(Server.MapPath("/Content/Images/small"), Guid.NewGuid() + Path.GetExtension(file.FileName)));

                //        }
                //    }
                //    db.Products.Add(prod);
                //    db.SaveChanges();
                //    return RedirectToAction("Index", "Product");
                //}
                _dbContext.Products.Add(prod);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            GetViewBagData();
            return View();
        }


        //Get Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = _dbContext.Products.Single(x => x.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            GetViewBagData();
            return View("Edit", product);
        }

        //Post Edit
        [HttpPost]
        public IActionResult Edit(Product prod)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(prod).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            GetViewBagData();
            return View(prod);
        }

        //Get Details
        public IActionResult Details(int id)
        {
            Product product = _dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //Get Delete
        public IActionResult Delete(int id)
        {
            Product product = _dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);

        }

        //Post Delete Confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Product product = _dbContext.Products.Find(id);
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
