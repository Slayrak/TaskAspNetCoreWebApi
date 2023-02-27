using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAspNetCoreWebApi.Domain.Models;

namespace TaskAspNetCoreWebApi.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasOne(x => x.Book)
                .WithMany(x => x.Ratings)
                .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<Review>()
                .HasOne(x => x.Book)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.BookId);
        }

    }
}
