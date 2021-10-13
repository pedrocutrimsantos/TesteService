using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TesteService.Core.Entities;

namespace TesteService.Core.Infrastructure.Context
{
    public class TesteDb : DbContext
    {
        public DbSet<TUser> Users { get; set; }
        public DbSet<TAccount> Accounts { get; set; }
        public DbSet<TTransfer> Transfers { get; set; }

        public TesteDb(DbContextOptions<TesteDb> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TUser>().ToTable("T01_USUARIOS");
            modelBuilder.Entity<TUser>().HasKey(x => x.ID);
            modelBuilder.Entity<TUser>().HasIndex(x => x.CPF_CNPJ);
            modelBuilder.Entity<TUser>().HasIndex(x => x.Email);
            modelBuilder.Entity<TUser>().HasOne(a => a.Account).WithOne(b => b.User).HasForeignKey<TAccount>(c => c.UserID);

            modelBuilder.Entity<TAccount>().ToTable("T02_CONTA");
            modelBuilder.Entity<TAccount>().HasKey(x => x.ID);
            modelBuilder.Entity<TAccount>().HasIndex(x => x.UserID);
            modelBuilder.Entity<TAccount>().Property(x => x.ID).IsRequired().HasColumnName("T02_ID");
            modelBuilder.Entity<TAccount>().Property(x => x.UserID).IsRequired().HasColumnName("T02_USERID");
            modelBuilder.Entity<TAccount>().Property(x => x.Cash).IsRequired().HasColumnName("T02_SALDO");

            modelBuilder.Entity<TAccount>().ToTable("T02_CONTA");
            modelBuilder.Entity<TAccount>().HasKey(x => x.ID);
            modelBuilder.Entity<TAccount>().HasIndex(x => x.UserID);

            modelBuilder.Entity<TTransfer>()
                .HasOne(f => f.Sender)
                .WithMany(f => f.Senders)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TTransfer>()
                .HasOne(f => f.Receiver)
                .WithMany(f => f.Receivers)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
