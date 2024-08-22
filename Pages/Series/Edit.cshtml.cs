using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZCB_Series.Data;
using ZCB_Series.Models;

namespace ZCB_Series.Pages.Series
{
    public class EditModel : PageModel
    {
        private readonly ZCB_Series.Data.ZCB_SeriesContext _context;

        public EditModel(ZCB_Series.Data.ZCB_SeriesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serie Series { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var series =  await _context.Series.FirstOrDefaultAsync(m => m.Id == id);
            if (series == null)
            {
                return NotFound();
            }
            Series = series;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Series).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeriesExists(Series.Id))
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

        private bool SeriesExists(int id)
        {
            return _context.Series.Any(e => e.Id == id);
        }
    }
}
