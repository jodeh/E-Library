using e_library.Models;
using Microsoft.EntityFrameworkCore;

namespace e_library.Data
{
    public class AppDbContext:DbContext
        
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Admin_info> Admin_info { get; set; }
        public DbSet<Specialist> Specialist { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<SubjectFiles> SubjectFiles { get; set; }
    }
}
