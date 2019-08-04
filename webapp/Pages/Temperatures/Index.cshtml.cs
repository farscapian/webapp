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
    public class IndexModel : PageModel
    {
        private readonly webapp.Models.webappContext _context;

        public IndexModel(webapp.Models.webappContext context)
        {
            _context = context;
        }

        public IList<Temperature> Temperature { get;set; }

        public async Task OnGetAsync()
        {
            Temperature = await _context.Temperature.ToListAsync();
        }
    }
}
