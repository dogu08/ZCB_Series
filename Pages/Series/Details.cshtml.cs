using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZCB_Series.Data;
using ZCB_Series.Models;

namespace ZCB_Series.Pages.Series
{
    public class DetailsModel : PageModel
    {
        private readonly ZCB_Series.Data.ZCB_SeriesContext _context;

        public DetailsModel(ZCB_Series.Data.ZCB_SeriesContext context)
        {
            _context = context;
        }

        public Serie Series { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var series = await _context.Series.FirstOrDefaultAsync(m => m.Id == id);
            if (series == null)
            {
                return NotFound();
            }
            else
            {
                Series = series;
            }
            return Page();
        }
    }
}
