using JobListingsBoard_API.Models;
using Microsoft.EntityFrameworkCore;

namespace JobListingsBoard_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        protected AppDbContext()
        {
        }

        public DbSet<JobListing> Jobs { get; set; }
    }
}
