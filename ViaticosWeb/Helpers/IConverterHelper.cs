using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaticosWeb.Data.Entities;
using ViaticosWeb.Models;

namespace ViaticosWeb.Helpers
{
    public interface IConverterHelper
    {
        CityViewModel ToCityViewModel(CityEntity cityEntity);

        Task<CityEntity> ToCityEntityAsync(CityViewModel model, bool isNew);
    }
}
