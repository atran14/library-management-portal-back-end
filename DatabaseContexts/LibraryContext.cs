using System;
using back_end.DatabaseContexts.Extensions;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.DatabaseContexts
{
    public class LibraryContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BorrowRequest> BorrowRequest { get; set; }
        public DbSet<BorrowRequestDetails> BorrowRequestDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
            options.UseSqlServer("Server=localhost;Database=library-db;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Book entity configurations
            builder.Entity<Book>()
                .Property(b => b.Name)
                .IsRequired();

            builder.Entity<Book>()
                .Property(b => b.Authors)
                .HasDefaultValue("Unknown");

            builder.Entity<Book>()
                .Property(b => b.Description)
                .HasDefaultValue("None");

            builder.Entity<Book>()
                .HasMany(b => b.BorrowRequestDetails)
                .WithOne(brd => brd.RequestedBook)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Category entity configurations
            builder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired();

            builder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region User entity configurations
            builder.Entity<User>()
                .Property(u => u.FirstName)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.DOB)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.Role)
                .HasDefaultValue(UserRole.NormalUser);

            builder.Entity<User>()
                .HasMany(u => u.BorrowRequests)
                .WithOne(br => br.RequestUser)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion            

            #region Borrow Request Details configurations
            builder.Entity<BorrowRequestDetails>()
                .HasOne(brd => brd.RequestedBook)
                .WithMany(b => b.BorrowRequestDetails)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Borrow Request configurations
            builder.Entity<BorrowRequest>()
                .Property(br => br.RequestUserId)
                .IsRequired();

            builder.Entity<BorrowRequest>()
                .Property(br => br.BorrowRequestDate)
                .ValueGeneratedOnAdd();

            builder.Entity<BorrowRequest>()
                .Property(br => br.BorrowUntilDate)
                .IsRequired();

            builder.Entity<BorrowRequest>()
                .Property(br => br.ActionStatus)
                .HasDefaultValue(BorrowRequestStatus.Pending);

            builder.Entity<BorrowRequest>()
                .HasMany(br => br.BorrowRequestDetails)
                .WithOne(brd => brd.BorrowRequest)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            builder.Seed();
        }
    }
}