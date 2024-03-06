using efcore_page.Data;
using Microsoft.EntityFrameworkCore;

namespace efcore_page.Data
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        public DbSet<InternshipPlace> Places = null!;
        public DbSet<Student> Students = null!; 
        public DbSet<InternshipRecord> Records = null!;

        // database-first: varolan db'i aktarmak
        // code-first: entity tanımlanır, dbcontext tanımlanır, db oluşturulunur(sqlite) - connection strings ile server'a aktarılcak
    }
}