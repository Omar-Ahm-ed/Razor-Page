using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_8.Models;

namespace Task_8.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly Models.Task5Context _context;
        public List<Models.Product> Products { get; set; }
       
            public IEnumerable<SelectListItem> CategoryList { get; set; }
        

        public CreateModel(Task5Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Product Product { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Products.Add(Product);
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
