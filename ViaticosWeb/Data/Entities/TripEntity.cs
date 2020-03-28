using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViaticosWeb.Data.Entities
{
    public class TripEntity
    {
        public int Id{ get; set; }

        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name="Trip's Tittle")]
        public string Tittle { get; set; }

        public ICollection<TripDetailEntity> TripDetails { get; set; }
    }
}
