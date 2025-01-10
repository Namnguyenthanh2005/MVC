using Microsoft.AspNetCore.Mvc;
using MVC_Group3.Data;
using MVC_Group3.Models;
using System.Security.Claims;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MVC_Group3.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: User/Cart
        public IActionResult Index()
        {
            // Lấy UserId từ Claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Truy vấn giỏ hàng cùng thông tin sản phẩm
            var cart = _db.Carts
                .Include(c => c.Shoe) // Load thông tin sản phẩm
                .Where(c => c.UserId == userId)
                .ToList();

            return View(cart);
        }

        // GET: User/Cart/Checkout
        public IActionResult Checkout()
        {
            // Trả về trang Checkout
            return View();
        }

        // POST: User/Cart/Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(Order order)
        {
            if (ModelState.IsValid)
            {
                // Lấy UserId từ Claims
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Liên kết đơn hàng với UserId
                order.UserId = userId;
                order.OrderDate = DateTime.Now;

                // Thêm đơn hàng vào cơ sở dữ liệu
                _db.Orders.Add(order);

                // Xóa giỏ hàng sau khi thanh toán
                var cartItems = _db.Carts.Where(c => c.UserId == userId).ToList();
                foreach (var item in cartItems)
                {
                    _db.Carts.Remove(item);
                }

                // Lưu thay đổi
                _db.SaveChanges();

                return RedirectToAction("Index", "UserShoe");
            }
            return View(order);
        }
    }
}
