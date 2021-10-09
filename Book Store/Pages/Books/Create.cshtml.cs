using Book_Store.Data;
using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_Store.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public CreateModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnPost()
        {
            dbContext.Books.InsertOne(Book);

            return RedirectToPage("./Index");
        }
    }
}
