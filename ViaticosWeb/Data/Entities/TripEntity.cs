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

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd }", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd }", ApplyFormatInEditMode = false)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public CityEntity City { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalAmount;

        public ICollection<TripDetailEntity> TripDetails { get; set; }


    }
}
