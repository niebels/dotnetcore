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
            Books = await _db.Book.ToListAsync(); // Async and await, instead of while.
        }
    }
}