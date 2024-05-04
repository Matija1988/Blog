using Blog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationContext _context;
        public CategoryController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();  
            return View(categories);
        }
    }
}

