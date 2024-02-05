using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<PrimeNumber> primenumbers { get; set; }
    // Diğer DbSet'ler buraya eklenebilir.S

    public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KJLUEAP; Database=case;Integrated Security=True;Encrypt=true;TrustServerCertificate=true;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PrimeNumber>()
            .HasOne(p => p.User)
            .WithMany(u => u.PrimeNumbers)
            .HasForeignKey(p => p.userId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete, kullanıcı silindiğinde ilgili PrimeNumbers'lar da silinsin

        // Diğer ilişki konfigürasyonları...
    }

}
