using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViaticosWeb.Data.Entities
{
    public class ExpenseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public IEnumerable<SelectListItem> TypeExpense { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Expense Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public DateTime Date { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Expense Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime DateLocal => Date.ToLocalTime();
        
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public Decimal Cost { get; set; }

        public string LogoPath { get; set; }



    }
}
