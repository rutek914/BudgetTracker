using BudgetTracker.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Model.Entities
{
    public class BudgetTrackerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userId1 = Guid.Parse("8c346ce9-09d4-4982-b4f8-ab6513686382");

            modelBuilder.Entity<User>(eb =>
            {
                eb.Property(user => user.Username).HasColumnType("varchar(200)");
                eb.Property(user => user.PasswordHash).HasMaxLength(60).IsRequired();
                eb.Property(user => user.Email).IsRequired();
                eb.HasIndex(user => user.Email).IsUnique();
                eb.HasData
                (
                    new User { Id = userId1, Username = "TestUser", PasswordHash="test", Email="test@test.com"}
                );
                //one user has many expenses
                eb.HasMany(u => u.Expenses).WithOne(e => e.User).HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<Expense>(eb =>
            {
                eb.Property(expense => expense.Description).HasColumnType("varchar(200)");
                eb.Property(expense => expense.Category).HasConversion<string>();
                eb.HasData
                (
                    new Expense { Id = 1, Description="kupilem ps5", Category = ExpenseCategory.Entertainment, UserId = userId1 }
                );
            });
        }
    }
}
