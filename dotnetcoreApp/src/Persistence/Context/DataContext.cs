using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Shout> Shouts { get; set; }
        public DbSet<Remark> Remarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Remark>()
                .HasData(
                    new Remark { Id = 1, Body = "Let's do it", ShoutId = 1 },
                    new Remark { Id = 2, Body = "Yay!!!!!!", ShoutId = 1 },
                    new Remark { Id = 3, Body = "NAY!!!!!!!!!", ShoutId = 1 },
                    new Remark { Id = 4, Body = "Let's go to night watch!", ShoutId = 2 },
                    new Remark { Id = 5, Body = "You know nothing John snow!", ShoutId = 2 },
                    new Remark { Id = 6, Body = "King in the north!", ShoutId = 2 }
                );

            modelBuilder.Entity<Shout>()
                .HasData(
                    new Shout
                    {
                        Id = 1,
                        Body = "Shout out loud!",
                        Upvotes = 5000,
                        Downvotes = 2000
                    },
                    new Shout
                    {
                        Id = 2,
                        Body = "Winter is coming!",
                        Upvotes = 1200,
                        Downvotes = 120
                    }
                );
        }
    }
}
