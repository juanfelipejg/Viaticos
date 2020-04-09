using System;
using System.Collections.Generic;
using System.Text;

namespace Viaticos.Common.Models
{
    public class TripResponse
    {
        public int Id { get; set; }


        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }

        public CityResponse City { get; set; }

        public decimal TotalAmount;

        public ICollection<TripDetailResponse> TripDetails { get; set; }
    }
}
