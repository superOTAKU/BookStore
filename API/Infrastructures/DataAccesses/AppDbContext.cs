using API.Modules.AclModule.Domains;
using API.Modules.AttachModule.Domains;
using API.Modules.BookModule.Domains;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Infrastructures.DataAccesses;

/// <summary>
/// 基础设施层
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Attach> Attaches { get; set; }

    public DbSet<AclRecord> AclRecords { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasKey(e => e.Id)
            .HasAnnotation("id", new DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity));
        modelBuilder.Entity<Book>()
            .HasKey(e => e.Id)
            .HasAnnotation("id", new DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity));
        modelBuilder.Entity<Book>()
            .HasOne(e => e.Author)
            .WithMany(e => e.Books)
            .HasForeignKey(e => e.AuthorId);
        modelBuilder.Entity<AclRecord>()
            .HasKey(e => e.Id)
            .HasAnnotation("id", new DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity));
        modelBuilder.Entity<AclRecord>()
            .HasIndex(e =>new 
            {
                e.EntityType, e.EntityId
            }, "EntityType_EntityId_Index");
        modelBuilder.Entity<Attach>()
            .HasKey(e => e.Id)
            .HasAnnotation("id", new DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity));
        modelBuilder.Entity<Attach>()
            .HasIndex(e => new
            {
                e.ComponentType,
                e.ComponentId
            }, "ComponentType_ComponentId_Index");
    }

}
