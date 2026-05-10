using Ecommerce.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>( user =>
            {
                user.HasKey(u => u.Id);
                user.Property(u => u.FirstName)
                    .HasMaxLength(50);

                user.Property(u => u.LastName)
                     .HasMaxLength(50);

                user.Property(u => u.Email)
                    .IsRequired();

                // relationship between user and order 1 --- many
                user.HasMany(u=>u.Orders)
                    .WithOne(u=>u.user)
                    .HasForeignKey(o=>o.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            }
            );

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);

                entity.Property(o => o.TotalAmount)
                      .HasColumnType("decimal(18,2)");

                entity.Property(o => o.Status)
                      .HasMaxLength(20);
            });

        }
       
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.;Database=E-CommerceStore;Trusted_Connection=True;TrustServerCertificate=True");
        //}

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

       
    }
}
