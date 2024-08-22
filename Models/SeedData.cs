using Microsoft.EntityFrameworkCore;
using ZCB_Series.Data;
namespace ZCB_Series.Models
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ZCB_SeriesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ZCB_SeriesContext>>()))
            {
                if (context == null || context.Series == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Series.Any())
                {
                    return;   // DB has been seeded
                }

                context.Series.AddRange(
                    new Serie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Rating = "R"

                    },

                    new Serie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Rating = "R"

                    },

                    new Serie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Rating = "R"

                    },

                    new Serie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "R"

                    }
                );
                context.SaveChanges();
            }
        }
    }
}