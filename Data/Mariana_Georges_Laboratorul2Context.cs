using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mariana_Georges_Laboratorul2.Models;

namespace Mariana_Georges_Laboratorul2.Data
{
    public class Mariana_Georges_Laboratorul2Context : DbContext
    {
        public Mariana_Georges_Laboratorul2Context (DbContextOptions<Mariana_Georges_Laboratorul2Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasOne(a => a.Borrowing)
                .WithOne(a => a.Book)
                .HasForeignKey<Borrowing>(c => c.BookID);
        }
        public DbSet<Mariana_Georges_Laboratorul2.Models.Book> Book { get; set; } = default!;

        public DbSet<Mariana_Georges_Laboratorul2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Mariana_Georges_Laboratorul2.Models.Author>? Author { get; set; }

        public DbSet<Mariana_Georges_Laboratorul2.Models.Category>? Category { get; set; }

        public DbSet<Mariana_Georges_Laboratorul2.Models.Member>? Member { get; set; }

        public DbSet<Mariana_Georges_Laboratorul2.Models.Borrowing>? Borrowing { get; set; }
    }
}
