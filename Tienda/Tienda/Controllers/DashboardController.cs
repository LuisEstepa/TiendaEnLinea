using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Tienda.Models;

namespace Tienda.Controllers
{
    public class DashboardController : Controller
    {
        private readonly TiendaContext _dbContext;
        public DashboardController(TiendaContext _db)
        {
            _dbContext = _db;
        }
        public IActionResult Index()
        {
            ViewBag.latestOrders = _dbContext.Orders.OrderByDescending(x => x.OrderID).Take(10).ToList();
            ViewBag.NewOrders = _dbContext.Orders.Where(a => a.DIspatched == false && a.Shipped == false && a.Deliver == false).Count();
            ViewBag.DispatchedOrders = _dbContext.Orders.Where(a => a.DIspatched == true && a.Shipped == false && a.Deliver == false).Count();
            ViewBag.ShippedOrders = _dbContext.Orders.Where(a => a.DIspatched == true && a.Shipped == true && a.Deliver == false).Count();
            ViewBag.DeliveredOrders = _dbContext.Orders.Where(a => a.DIspatched == true && a.Shipped == true && a.Deliver == true).Count();

            return View();
        }

        //Area Grap
        public JsonResult GetSalesPerDay()
        {
            var data = (from O in _dbContext.Orders
                        select new { date = O.OrderDate, O.TotalAmount } into a
                        group a by a.date into b
                        select new
                        {
                            period = b.Key,
                            sales = b.Sum(x => x.TotalAmount)
                        });

            List<AreaCharts> aa = new List<AreaCharts>();
            foreach (var item in data)
            {
                string date = item.period.ToString().Split(new[] { (' ') }, StringSplitOptions.None)[0];
                aa.Add(new AreaCharts() { period = date, sales = item.sales.GetValueOrDefault() });
            }
            return Json(aa, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        //Circle Graph
        public JsonResult GetTopProductSales()
        {
            var dataforchart = (from OD in _dbContext.OrderDetails
                                join P in _dbContext.Products
                                on OD.ProductID equals P.ProductID
                                select new { P.Name, OD.Quantity } into row
                                group row by row.Name into g
                                select new
                                {
                                    label = g.Key,
                                    value = g.Sum(x => x.Quantity)
                                })
                    .OrderByDescending(x => x.value)
                    .Take(3);
            return Json(dataforchart, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }


        //Line Grap
        public JsonResult GetOrderPerDay()
        {
            var data = from O in _dbContext.Orders
                       select new { Odate = O.OrderDate, O.OrderID } into g
                       group g by g.Odate into col
                       select new
                       {
                           Order_Date = col.Key,
                           Count = col.Count(y => y.OrderID != null)
                       };
            List<LineCharts> aa = new List<LineCharts>();
            foreach (var item in data)
            {
                string date = item.Order_Date.ToString().Split(new[] { (' ') }, StringSplitOptions.None)[0];
                aa.Add(new LineCharts() { Date = date, Orders = item.Count });
            }
            return Json(aa, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        //Bar Grap
        public JsonResult GetSalesPerCountry()
        {
            var dataforBarchart = (from O in _dbContext.Orders
                                   join C in _dbContext.Customers
                                   on O.CustomerID equals C.CustomerID
                                   select new { C.Country, O.TotalAmount } into row
                                   group row by row.Country into g
                                   select new
                                   {
                                       Country = g.Key,
                                       Sales_Amount = g.Sum(x => x.TotalAmount)
                                   })
                              .OrderByDescending(x => x.Sales_Amount)
                              .Take(6);
            return Json(dataforBarchart, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
    }
}
