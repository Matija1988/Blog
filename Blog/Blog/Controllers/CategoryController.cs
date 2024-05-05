using Blog.Data;
using Blog.Models;
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

            if (categories == null || categories.Count < 0)
            {
                return NotFound("Entity list not found!!!");
            }

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category entity)
        {
            var Categories = _context.Categories.ToList();
            int Order = 1;

            List<int> OrderList = Categories.Select(s => s.DisplayOrder).Distinct().ToList();

            if(OrderList.Any(o => o.Equals(entity.DisplayOrder))) 
            { 
                
                OrderList.ForEach(o =>
                {
                    if (o.Equals(Order))
                    {
                        Order++;
                    }
                });

                entity.DisplayOrder = Order;

            }

            if (entity.DisplayOrder == 0)
            {
                entity.DisplayOrder = Order + Categories.Count;
            }

            if (entity.Name != null && entity.CategoryDescription != null)
            {
                _context.Categories.Add(entity);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();

        }


    }
}

