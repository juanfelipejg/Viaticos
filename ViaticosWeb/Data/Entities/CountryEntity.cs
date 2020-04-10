using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViaticosWeb.Data.Entities
{
    public class CountryEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        public ICollection<CityEntity> Cities { get; set; }
    }
}