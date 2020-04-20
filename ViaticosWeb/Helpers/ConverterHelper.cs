using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaticosWeb.Data;
using ViaticosWeb.Data.Entities;
using ViaticosWeb.Models;
using Viaticos.Common.Models;
using Viaticos.Web.Data.Entities;

namespace ViaticosWeb.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;

        public ConverterHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CityEntity> ToCityEntityAsync(CityViewModel model, bool isNew)
        {
            return new CityEntity
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                Country = await _dataContext.Countries.FindAsync(model.CountryId)
            };
        }

        public CityResponse ToCityResponse(CityEntity cityEntity)
        {
            if (cityEntity == null)
            {
                return null;
            }

            return new CityResponse
            {
                Id = cityEntity.Id,
                Name = cityEntity.Name,
            };
        }

        public CityViewModel ToCityViewModel(CityEntity cityEntity)
        {
            return new CityViewModel
            {
                Id = cityEntity.Id,
                Name = cityEntity.Name,
                Country = cityEntity.Country,
                CountryId= cityEntity.Country.Id
            };
        }

        public CountryResponse ToCountryResponse(CountryEntity countryEntity)
        {
            if (countryEntity == null)
            {
                return null;
            }
            return new CountryResponse
            {
                Id = countryEntity.Id,
                Name = countryEntity.Name,
                Cities = countryEntity.Cities?.Select(c => new CityResponse
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
            };
        }

        public ExpenseTypeResponse ToExpenseTypeResponse(ExpenseTypeEntity expenseTypeEntity)
        {
            if (expenseTypeEntity == null)
            {
                return null;
            }

            return new ExpenseTypeResponse
            {
                Id = expenseTypeEntity.Id,
                Name = expenseTypeEntity.Name,
            };
        }
        public TripResponse ToTripResponse(TripEntity tripEntity)
        {
            return new TripResponse
            {
                Id = tripEntity.Id,
                Name = tripEntity.Name,
                StartDate = tripEntity.StartDate,
                EndDate = tripEntity.EndDate,
                City = ToCityResponse(tripEntity.City),
                TripDetails = tripEntity.TripDetails?.Select(t => new TripDetailResponse
                {
                    Id = t.Id,
                    TypeExpense = ToExpenseTypeResponse(t.TypeExpense),
                    Date = t.Date,
                    Amount = t.Amount,
                    Description = t.Description,
                    PicturePath = t.PicturePath
                }).ToList(),
                User =ToUserResponse(tripEntity.User)
            };
        }
        public List<TripResponse> ToTripResponse(List<TripEntity> tripEntities)
        {
            List<TripResponse> list = new List<TripResponse>();
            foreach (TripEntity tripEntity in tripEntities)
            {
                list.Add(ToTripResponse(tripEntity));
            }

            return list;
        }
        public UserResponse ToUserResponse(UserEntity user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserResponse
            {
                Address = user.Address,
                Document = user.Document,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType
            };
        }
    }
}
