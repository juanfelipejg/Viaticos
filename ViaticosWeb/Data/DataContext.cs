using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaticosWeb.Data.Entities;

namespace ViaticosWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

        public DbSet<CityEntity> Cities { get; set; }

        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<ExpenseEntity> Expenses { get; set; }
        
        public DbSet<ExpenseTypeEntity> ExpensesType { get; set; }

        public DbSet<TripDetailEntity> TripDetails { get; set; }

        public DbSet<TripEntity> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ExpenseTypeEntity>()
                .HasIndex(e => e.TypeExpense)
                .IsUnique();
        }

    }
}
