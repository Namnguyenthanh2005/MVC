using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC_Group3.Data;

namespace MVC_Group3.Controllers
{
    public class ShoeController : Controller
    {
       
        private readonly ApplicationDbContext _db;

        public ShoeController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: User/Shoe
        public IActionResult Index()
        {
            var shoes = _db.Shoes.ToList();
            return View(shoes);
        }
    }
}
