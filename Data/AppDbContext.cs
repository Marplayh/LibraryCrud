using Microsoft.EntityFrameworkCore;
using LibraryCrud.Entities;
using LibraryCrud.Entities.interfaces;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books)
            .UsingEntity(j => j.ToTable("BookAuthors"));

        modelBuilder.Entity<Library>()
            .HasMany(l => l.Shelves)
            .WithOne()
            .HasForeignKey(s => s.LibraryId);
            
        modelBuilder.Entity<Shelf>()
            .HasMany(s => s.Copies)
            .WithOne()
            .HasForeignKey(c => c.ShelfId);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property("Id")
                    .HasDefaultValueSql("gen_random_uuid()");
            }
        }
    }
    public DbSet<Library> Libraries { get; set; }
    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookCopy> BookCopies { get; set; }
}