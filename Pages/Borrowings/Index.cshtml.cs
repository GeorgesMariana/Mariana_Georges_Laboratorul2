using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mariana_Georges_Laboratorul2.Data;
using Mariana_Georges_Laboratorul2.Models;

namespace Mariana_Georges_Laboratorul2.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Mariana_Georges_Laboratorul2.Data.Mariana_Georges_Laboratorul2Context _context;

        public IndexModel(Mariana_Georges_Laboratorul2.Data.Mariana_Georges_Laboratorul2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Borrowing != null)
            {
                Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .ThenInclude(b => b.Author)
                .Include(b => b.Member).ToListAsync();
            }
        }
    }
}
