using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Group3.Data;
using MVC_Group3.Models;

namespace MVC_Group3.Controllers
{
   
    public class AdminOrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminOrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Admin/Order
        public IActionResult Index()
        {
            var orders = _db.Orders.ToList();
            return View(orders);
        }

        // GET: Admin/Order/Details/5
        public IActionResult Details(int id)
        {
            var order = _db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}
