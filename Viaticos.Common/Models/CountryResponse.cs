using System;
using System.Collections.Generic;
using System.Text;

namespace Viaticos.Common.Models
{
    public class CountryResponse
    {
        public int Id { get; set; }

     
        public string Name { get; set; }

        public ICollection<CityResponse> Cities { get; set; }

    }
}
