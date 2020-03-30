using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViaticosWeb.Data.Entities
{
    public class ExpenseTypeEntity
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string TypeExpense { get; set; }
    }
}
