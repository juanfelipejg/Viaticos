using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaticosWeb.Data.Entities;

namespace ViaticosWeb.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckExpenseTypeAsync();
            await CheckCountryAsync();
        }

        private async Task CheckExpenseTypeAsync()
        {
            if (!_context.ExpenseTypes.Any())
            {
                AddExpenseType("Alimentación");
                AddExpenseType("Transporte");
                AddExpenseType("Hospedaje");
                AddExpenseType("Representacion");
                await _context.SaveChangesAsync();
            }
        }

        private void AddExpenseType(string ExpenseName)
        {
            _context.ExpenseTypes.Add(new ExpenseTypeEntity { Name = ExpenseName});
        }

        private async Task CheckCountryAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new CountryEntity
                {
                    Name = "Colombia",
                    Cities = new List<CityEntity>
                 {
                 new CityEntity
                 {
                 Name = "Medellin"
                 },
                 new CityEntity
                 {
                 Name = "Bogota"
                 }
                 }
                });
                await _context.SaveChangesAsync();
            }



        }


    }
}
