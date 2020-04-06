using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaticosWeb.Data.Entities;

namespace ViaticosWeb.Models
{
    public class CityViewModel : CityEntity
    {
        public int CountryId { get; set; }
    }
}
