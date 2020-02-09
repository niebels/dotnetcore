using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db; // Dependency Injection.
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet() // await requires "public async Task" instead of "public void".
        {
            Books = await _db.Book.ToListAsync(); // await instead of while.
        }

        public async Task<IActionResult> OnPostAsyncDeleteThisMothaFokka(int id)
        {
            var book = await _db.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDeleteThisMothaFokka(int id)
        {
            var book = await _db.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}