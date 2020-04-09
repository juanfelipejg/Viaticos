
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

        TripDetailResponse ToTripDetailResponse(TripDetailEntity tripDetailEntity);

        ExpenseTypeResponse ToExpenseTypeResponse(ExpenseTypeEntity expenseTypeEntity);

        CityResponse ToCityResponse(CityEntity cityEntity);

        CountryResponse ToCountryResponse(CountryEntity countryEntity);

    }
}
