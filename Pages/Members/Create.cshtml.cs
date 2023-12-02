using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mariana_Georges_Laboratorul2.Data;
using Mariana_Georges_Laboratorul2.Models;

namespace Mariana_Georges_Laboratorul2.Pages.Members
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
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Member == null || Member == null)
            {
                return Page();
            }

            _context.Member.Add(Member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
