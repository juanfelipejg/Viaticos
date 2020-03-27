﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViaticosWeb.Data.Entities
{
    public class TripEntity
    {
        public int Id{ get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd }", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }


        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd }", ApplyFormatInEditMode = false)]
        public DateTime EndDate { get; set; }

        public ICollection<TripDetailEntity> TripDetails { get; set; }
    }
}
