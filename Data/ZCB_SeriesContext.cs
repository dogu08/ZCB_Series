using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZCB_Series.Models;

namespace ZCB_Series.Data
{
    public class ZCB_SeriesContext : DbContext
    {
        public ZCB_SeriesContext (DbContextOptions<ZCB_SeriesContext> options)
            : base(options)
        {
        }

        public DbSet<ZCB_Series.Models.Serie> Series { get; set; } = default!;
    }
}
