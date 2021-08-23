using Microsoft.EntityFrameworkCore;
using Tython.Models;

namespace Tython.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Planet> Planets { get; set; }

        public DbSet<Region> Regions { get; set; }
    }
}