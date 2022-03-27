using Microsoft.EntityFrameworkCore;
using IWantApp.Domain.Products;
using Flunt.Notifications;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.Infra.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
        
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //Modelar o banco de dados de acordo com as classes
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<Notification>();

        builder.Entity<Product>().Property(p => p.Name).IsRequired();
        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(500);

        builder.Entity<Category>().Property(c => c.Name).IsRequired();

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>().HaveMaxLength(100);
    }
}