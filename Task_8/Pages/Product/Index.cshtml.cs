using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task_8.Models;

namespace Task_8.Pages.Product
{
    public class IndexModel : PageModel
    {

        private readonly  Models.Task5Context _context;
      public  List<Models.Product> Products { get; set; }
        public IndexModel(Task5Context context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            //Products = _context.Products.ToList();
            Products = _context.Products
                     .Include(p => p.Category) 
                     .ToList();
            return Page();
        }
    }
}
