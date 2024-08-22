using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZCB_Series.Data;
using ZCB_Series.Models;

namespace ZCB_Series.Pages.Series
{
    public class CreateModel : PageModel
    {
        private readonly ZCB_Series.Data.ZCB_SeriesContext _context;

        public CreateModel(ZCB_Series.Data.ZCB_SeriesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Serie Series { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Series.Add(Series);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
