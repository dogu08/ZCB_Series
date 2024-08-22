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
    public class IndexModel : PageModel
    {
        private readonly ZCB_Series.Data.ZCB_SeriesContext _context;

        public IndexModel(ZCB_Series.Data.ZCB_SeriesContext context)
        {
            _context = context;
        }

        public IList<Serie> Series { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SerieGenre { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Series
                                            orderby m.Genre
                                            select m.Genre;
            var dizi = from m in _context.Series
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                dizi = dizi.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SerieGenre))
            {
                dizi = dizi.Where(x => x.Genre == SerieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Series = await dizi.ToListAsync();
        }
    }
}
