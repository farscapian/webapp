using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webapp.Models;

namespace webapp.Pages.Temperatures
{
    public class DeleteModel : PageModel
    {
        private readonly webapp.Models.webappContext _context;

        public DeleteModel(webapp.Models.webappContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Temperature Temperature { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Temperature = await _context.Temperature.FirstOrDefaultAsync(m => m.ID == id);

            if (Temperature == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Temperature = await _context.Temperature.FindAsync(id);

            if (Temperature != null)
            {
                _context.Temperature.Remove(Temperature);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
