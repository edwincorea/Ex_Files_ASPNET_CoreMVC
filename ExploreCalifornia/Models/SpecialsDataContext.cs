using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ExploreCalifornia.Models
{
    public class SpecialsDataContext : DbContext
    {
        public DbSet<Special> Specials { get; set; }

        public SpecialsDataContext(DbContextOptions<SpecialsDataContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        public IEnumerable<Special> GetMonthlySpecials()
        {
            return Specials.ToList();
        }
    }
}
