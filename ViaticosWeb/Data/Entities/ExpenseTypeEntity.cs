using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViaticosWeb.Data.Entities
{
    public class ExpenseTypeEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Name { get; set; }
        public ICollection<TripDetailEntity> TripDetails { get; set; }
    }
}
