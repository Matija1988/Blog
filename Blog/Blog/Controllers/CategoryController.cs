using Azure.Core;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            
            List<int> OrderList = Categories.Select(s => s.DisplayOrder).ToList();

            if (!OrderList.Any(o => o.Equals(entity.DisplayOrder)) && entity.DisplayOrder > 0)
            {
                entity.DisplayOrder = entity.DisplayOrder;
            }
            else
            {
                foreach (var category in Categories)
                {
                    if (OrderList.Any(o => o.Equals(entity.DisplayOrder)) || entity.DisplayOrder <= 0)
                    {
                        Order++;
                    }
                    entity.DisplayOrder = Order + 1;
                }
            }
            
            if (entity.Name != null && entity.CategoryDescription != null)
            {
                _context.Categories.Add(entity);
                _context.SaveChanges();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var category = _context.Categories.Find(id);

            if(category == null)
            {
                return NotFound();  
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category entity)
        {
            var Categories = _context.Categories.ToList();

            int Order = 1;

            List<int> OrderList = Categories.Select(s => s.DisplayOrder).ToList();

            if (!OrderList.Any(o => o.Equals(entity.DisplayOrder)) && entity.DisplayOrder > 0)
            {
                entity.DisplayOrder = entity.DisplayOrder;
            } 
            else
            {
                foreach (var category in Categories)
                {
                    if (OrderList.Any(o => o.Equals(entity.DisplayOrder)) || entity.DisplayOrder <= 0)
                    {
                        Order++;
                    }
                    entity.DisplayOrder = Order + 1;
                }
            }

            if (ModelState.IsValid)
            {
                _context.Categories.Update(entity);
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var entity = _context.Categories.Find(id)
                ?? throw new Exception("Entity with id" + id + " not found in database!");


            return View(entity);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteCategory(Category entity)
        {
            
            _context.Categories.Remove(entity);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");           
        }
    }
}

