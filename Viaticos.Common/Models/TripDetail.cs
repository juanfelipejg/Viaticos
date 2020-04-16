using System;
using System.Collections.Generic;
using System.Text;

namespace Viaticos.Common.Models
{
    class TripDetail
    {
        public ExpenseTypeResponse TypeExpense { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
    }
}
