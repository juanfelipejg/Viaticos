using Soccer.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viaticos.Common.Enums;
using ViaticosWeb.Data.Entities;
using ViaticosWeb.Helpers;

namespace ViaticosWeb.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckExpenseTypeAsync();
            await CheckCountryAsync();
            await CheckUserAsync("1010", "Juan", "Jaramillo", "juanfelipejg@gmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Admin);
            await CheckUserAsync("2020", "Juan", "Jaramillo", "juanfelipejg@hotmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
        }

        private async Task<UserEntity> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
            {
            UserEntity user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

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
            _context.ExpenseTypes.Add(new ExpenseTypeEntity { Name = ExpenseName });
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
