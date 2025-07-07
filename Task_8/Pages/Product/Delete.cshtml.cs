using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task_8.Models;

namespace Task_8.Pages.Product
{
    public class DeleteModel : PageModel
    {
        
            private readonly Task5Context _context;

            public DeleteModel(Task5Context context)
            {
                _context = context;
            }

            [BindProperty]
           public Models.Product Product { get; set; }


        public IActionResult OnGet(int id)
            {
                Product = _context.Products.FirstOrDefault(p => p.Id == id);
                if (Product == null)
                {
                    return NotFound();
                }
                return Page();
            }

            public IActionResult OnPost()
            {
                var productToDelete = _context.Products.Find(Product.Id);
                if (productToDelete == null)
                {
                    return NotFound();
                }

                _context.Products.Remove(productToDelete);
                _context.SaveChanges();

                return RedirectToPage("Index");
            }
    }
      
}

