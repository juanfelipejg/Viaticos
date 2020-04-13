using Soccer.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viaticos.Common.Models;
using ViaticosWeb.Data.Entities;
using ViaticosWeb.Models;

namespace ViaticosWeb.Helpers
{
    public interface IConverterHelper
    {
        CityViewModel ToCityViewModel(CityEntity cityEntity);

        Task<CityEntity> ToCityEntityAsync(CityViewModel model, bool isNew);

        TripResponse ToTripResponse(TripEntity tripEntity);

        List<TripResponse> ToTripResponse(List<TripEntity> tripEntities);

        ExpenseTypeResponse ToExpenseTypeResponse(ExpenseTypeEntity expenseTypeEntity);

        CityResponse ToCityResponse(CityEntity cityEntity);

        CountryResponse ToCountryResponse(CountryEntity countryEntity);

        UserResponse ToUserResponse(UserEntity user);
    }
}
