using System.ComponentModel.DataAnnotations;

namespace ViaticosWeb.Data.Entities
{
    public class CityEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        public CountryEntity Country { get; set; }
    }
}
