using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceManager.Domain.Entities;

namespace PersonalFinanceManager.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<BankAccount> BankAccounts => Set<BankAccount>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id); // Chave primária

                entity.Property(t => t.Description)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(t => t.Amount)
                      .HasColumnType("decimal(18,2)");

                entity.HasOne(t => t.BankAccount)
                      .WithMany(b => b.Transactions)
                      .HasForeignKey(t => t.BankAccountId);

                entity.HasOne(t => t.Category)
                      .WithMany(c => c.Transactions)
                      .HasForeignKey(t => t.CategoryId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.Name)
                      .HasMaxLength(100)
                      .IsRequired();
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.Property(b => b.Name)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(b => b.Balance)
                      .HasColumnType("decimal(18,2)");
            });
        }
    }
}
