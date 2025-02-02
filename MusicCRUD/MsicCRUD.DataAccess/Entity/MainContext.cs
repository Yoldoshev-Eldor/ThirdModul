using Microsoft.EntityFrameworkCore;

namespace MsicCRUD.DataAccess.Entity;

public class MainContext : DbContext
{
    public DbSet<Music> Music { get; set; }

    //public MainContext (DbContextOptions<MainContext> options)
    //    : base(options)
    //{

    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KJBVCO8\\SQLEXPRESS;Database=MusicCRUd;User Id=sa;Password=1;TrustServerCertificate=True;MultipleActiveResultSets=true");
}

        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
