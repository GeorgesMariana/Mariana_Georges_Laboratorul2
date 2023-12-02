using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mariana_Georges_Laboratorul2.Data;
using Mariana_Georges_Laboratorul2.Models;
using Microsoft.EntityFrameworkCore;

namespace Mariana_Georges_Laboratorul2.Pages.Borrowings
{
    public class CreateModel : PageModel
    {
        private readonly Mariana_Georges_Laboratorul2.Data.Mariana_Georges_Laboratorul2Context _context;

        public CreateModel(Mariana_Georges_Laboratorul2.Data.Mariana_Georges_Laboratorul2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bookList = _context.Book
              .Include(b => b.Author)
              .Select(x => new
        {
               x.ID,
               BookFullName = x.Title + " - " + x.Author.LastName + " " +
               x.Author.FirstName
              });
            ViewData["BookID"] = new SelectList(bookList , "ID" , "BookFullName" );
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName" );
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Borrowing == null || Borrowing == null)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
