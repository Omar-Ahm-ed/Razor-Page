using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task_8.Models;

namespace Task_8.Pages.Product
{
    public class UpdateModel : PageModel
    {
        private readonly Models.Task5Context _context;
        //public List<Models.Product> Products { get; set; }
        public UpdateModel(Task5Context context)
        {
            _context = context;
        }
        [BindProperty]
        public Models.Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = _context.Products
                       .Include(p => p.Category)
                       .FirstOrDefault(p => p.Id == id);
            if (Product == null)
                return NotFound();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Products.Update(Product);
                    _context.SaveChanges();
                    return RedirectToPage("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + ex.Message);
                    return Page();
                }

            }
            return Page();
        }
    }

}

