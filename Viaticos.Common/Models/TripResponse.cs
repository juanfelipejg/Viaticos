using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Viaticos.Common.Models
{
    public class TripResponse
    {
        public int Id { get; set; }
        public string Name {get;set;}
        public DateTime StartDate { get; set; }
        public DateTime StartDateLocal => StartDate.ToLocalTime();
        public DateTime EndDate { get; set; }
        public DateTime EndDateLocal => EndDate.ToLocalTime();
        public CityResponse City { get; set; }
        public ICollection<TripDetailResponse> TripDetails { get; set; }
        public decimal TotalAmount => TripDetails.Sum(x => x.Amount);
        public UserResponse User { get; set; }
    }
}
