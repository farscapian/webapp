using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapp.Models;

namespace webapp.Pages.Temperatures
{
    public class EditModel : PageModel
    {
        private readonly webapp.Models.webappContext _context;

        public EditModel(webapp.Models.webappContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Temperature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemperatureExists(Temperature.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TemperatureExists(int id)
        {
            return _context.Temperature.Any(e => e.ID == id);
        }
    }
}
