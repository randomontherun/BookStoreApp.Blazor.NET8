using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data;

public partial class BookAppDbContext : IdentityDbContext<ApiUser>
{
    public BookAppDbContext()
    {
    }

    public BookAppDbContext(DbContextOptions<BookAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(60);
            entity.Property(e => e.LastName).HasMaxLength(60);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Isbn).HasMaxLength(20);
            entity.Property(e => e.Summary).HasMaxLength(60);
            entity.Property(e => e.Title).HasMaxLength(30);

            entity.HasOne(d => d.Author).WithMany(p => p.Books).HasForeignKey(d => d.AuthorId);
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "781d5294-ceaf-40cb-a5a0-d67d0d1d742f"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "53bde38f-cfd7-49d5-aaf5-dec0577b9194"
            }

        );

        var hasher = new PasswordHasher<ApiUser>();

        modelBuilder.Entity<ApiUser>().HasData(
            new ApiUser
            {
                Id = "a9cafc2e-7313-43e7-9ff8-94be0f30b528",
                Email = "admin@bookstore.com",
                NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                UserName = "admin@bookstore.com",
                NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            },
            new ApiUser
            {
                Id = "f5ec879c-b0b0-4292-a3a6-7628377f696a",
                Email = "user@bookstore.com",
                NormalizedEmail = "USER@BOOKSTORE.COM",
                UserName = "user@bookstore.com",
                NormalizedUserName = "USER@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            }

        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "53bde38f-cfd7-49d5-aaf5-dec0577b9194",
                UserId = "f5ec879c-b0b0-4292-a3a6-7628377f696a"
            },
            new IdentityUserRole<string>
            {
                RoleId = "781d5294-ceaf-40cb-a5a0-d67d0d1d742f",
                UserId = "f5ec879c-b0b0-4292-a3a6-7628377f696a"
            }
        );



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
