using Bloog_temp.Data;
using Bloog_temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloog_temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly RazorApplicationContext _context;

        public List<Category> CategoryList { get; set; }

        public IndexModel(RazorApplicationContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            CategoryList = _context.Categories.ToList();
        }


    }
}
