using System;
using System.ComponentModel.DataAnnotations;

namespace ViaticosWeb.Data.Entities
{
    public class TripDetailEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public ExpenseTypeEntity TypeExpense { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        public DateTime DateLocal => Date.ToLocalTime();

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Description { get; set; }

        public string PicturePath { get; set; }

        public TripEntity Trip { get; set; }

        
    }
}
