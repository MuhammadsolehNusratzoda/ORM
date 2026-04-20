using efcore_intro.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
      public DbSet<User> Users { get; set; }
      public DbSet<Category> Categories { get; set; }
      public DbSet<Product> Products { get; set; }
      public DbSet<Student> Students { get; set; }
      public DbSet<Group> Groups { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {

            modelBuilder.Entity<StudentGroup>()
                .HasKey(sg => new { sg.StudentId, sg.GroupId });

            modelBuilder.Entity<StudentGroup>()
                .HasOne(sg => sg.Student)
                .WithMany(s => s.StudentGroups)
                .HasForeignKey(sg => sg.StudentId);

            modelBuilder.Entity<StudentGroup>()
                .HasOne(sg => sg.Group)
                .WithMany(g => g.StudentGroups)
                .HasForeignKey(sg => sg.GroupId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Student>(entity =>
            {
                  entity.HasKey(x => x.Id);

                  entity.Property(x => x.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                  entity.Property(x => x.Age)
                    .IsRequired();
            });

            modelBuilder.Entity<Group>(entity =>
            {
                  entity.HasKey(x => x.Id);

                  entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                  entity.HasKey(x => x.Id);

                  entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                  entity.Property(x => x.Description)
                    .HasMaxLength(250);

                  entity.Property(x => x.Price)
                    .HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                  entity.HasKey(x => x.Id);

                  entity.Property(x => x.Username)
                    .IsRequired()
                    .HasMaxLength(100);

                  entity.Property(x => x.Age)
                    .IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                  entity.HasKey(x => x.Id);

                  entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            base.OnModelCreating(modelBuilder);
      }
}