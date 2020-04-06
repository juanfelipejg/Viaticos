using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaticosWeb.Data;
using ViaticosWeb.Data.Entities;
using ViaticosWeb.Models;

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
    }
}
