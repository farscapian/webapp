using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using webapp.Models;

namespace webapp.Pages.Temperatures
{
    public class CreateModel : PageModel
    {
        private readonly webapp.Models.webappContext _context;

        public CreateModel(webapp.Models.webappContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Temperature Temperature { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Temperature.Add(Temperature);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}