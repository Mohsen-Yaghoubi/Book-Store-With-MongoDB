using Book_Store.Data;
using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using System.Linq;

namespace Book_Store.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public EditModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet(string id)
        {
            Book = dbContext.Books.Find(x => x.Id == id).SingleOrDefault();
        }

        public IActionResult OnPost()
        {
            dbContext.Books.ReplaceOne(x => x.Id == Book.Id, Book);

            return RedirectToPage("./Index");
        }
    }
}
