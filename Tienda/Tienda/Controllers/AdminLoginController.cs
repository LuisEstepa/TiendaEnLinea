using DataLayer;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tienda.Controllers
{
    [Authorize]
    public class AdminLoginController : Controller
    {
        private readonly TiendaContext _dbContext;
        private readonly ILogger<HomeController> _logger;
       
        public AdminLoginController(ILogger<HomeController> logger, TiendaContext _db)
        {             
            _logger = logger;
            _dbContext = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AdminLogin login)
        {
            if (ModelState.IsValid)
            {
                var model = (from m in _dbContext.AdminLogin
                             where m.UserName == login.UserName && m.Password == login.Password
                             select m).Any();
                if (model)
                {
                    var loginInfo = _dbContext.AdminLogin.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
                    HttpContext.Session.SetString("username", loginInfo.UserName);
                    TemData.EmpID = loginInfo.EmpID;
                    return RedirectToAction("Index", "Dashboard");
                }                
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "AdminLogin");
        }
        
    }
}
