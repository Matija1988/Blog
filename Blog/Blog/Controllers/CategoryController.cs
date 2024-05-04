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

            if(categories == null || categories.Count < 0)
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
            if(!ModelState.IsValid) 
            { 
              return StatusCode(StatusCodes.Status400BadRequest, "Model state is not valid!!!");
            }

            _context.Categories.Add(entity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

