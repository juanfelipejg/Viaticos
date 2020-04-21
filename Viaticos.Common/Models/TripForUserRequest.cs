using System;
using System.ComponentModel.DataAnnotations;

namespace Viaticos.Common.Models
{
    public class TripForUserRequest
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public Guid UserId { get; set; }

        [Required]
        public string CultureInfo { get; set; }
    }
}

