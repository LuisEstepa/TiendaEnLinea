using DataLayer;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tienda.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly TiendaContext _dbContext;

        public OrderController(TiendaContext _db)
        {
            _dbContext = _db;
        }
        // GET: Order
        public ActionResult Index()
        {
            return View(_dbContext.Orders.OrderByDescending(x => x.OrderID).ToList());
        }
        public ActionResult Details(int id)
        {
            Order ord = _dbContext.Orders.Find(id);
            var Ord_details = _dbContext.OrderDetails.Where(x => x.OrderID == id).ToList();
            var tuple = new Tuple<Order, IEnumerable<OrderDetail>>(ord, Ord_details);

            double SumAmount = Convert.ToDouble(Ord_details.Sum(x => x.TotalAmount));
            ViewBag.TotalItems = Ord_details.Sum(x => x.Quantity);
            ViewBag.Discount = 0;
            ViewBag.TAmount = SumAmount - 0;
            ViewBag.Amount = SumAmount;
            return View(tuple);
        }
    }
}
