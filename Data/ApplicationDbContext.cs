using efcore_intro.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): DbContext(options)
{
    public DbSet<User> Users {get; set;}   
    public DbSet<Category> Categories {get; set;}
    public DbSet<Product> Products {get; set;}

    public DbSet<Student> Students {get; set;}
    public DbSet<Group> Groups {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentGroup>()
        .HasKey(sg => new {sg.StudentId, sg.GroupId});
        base.OnModelCreating(modelBuilder);
    }
}