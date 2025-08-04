using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Data;

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
  public DbSet<User> Users => Set<User>();
  public DbSet<Post> Posts => Set<Post>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>()
                .ToTable("Users");

    modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

    modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100);

    modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();

    modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

    modelBuilder.Entity<Post>()
                .ToTable("Posts");

    modelBuilder.Entity<Post>()
                .HasKey(p => p.Id);

    modelBuilder.Entity<Post>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

    modelBuilder.Entity<Post>()
                .Property(p => p.Content)
                .IsRequired();

    modelBuilder.Entity<Post>()
                .Property(p => p.CreatedAt)
                .IsRequired();

    modelBuilder.Entity<Post>()
                .HasOne(p => p.Author)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);
  }
}