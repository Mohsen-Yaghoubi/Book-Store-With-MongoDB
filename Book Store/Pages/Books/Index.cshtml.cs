using Book_Store.Data;
using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Book_Store.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public IndexModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public IEnumerable<Book> Books { get; set; }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var filter = Builders<Book>.Filter.Eq("Name", name);

                Books = dbContext.Books.AsQueryable()
                    .Where(x => x.Name.Contains(name))
                    .ToList();

                return Page();
            }
            Books = dbContext.Books.Find(FilterDefinition<Book>.Empty).ToList();
            return Page();
        }
        public IActionResult OnGetDelete(string id)
        {
            dbContext.Books.DeleteOne(x => x.Id == id);

            return RedirectToPage("./Index");
        }
    }
}
