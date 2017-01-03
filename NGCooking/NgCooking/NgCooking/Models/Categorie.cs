using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgCooking.Models
{
    public class Categorie
    {
        [Key]
        [StringLength(30)]
        public string id { get; set; }

        [Required]
        [StringLength(30)]
        public string nameToDisplay { get; set; }

        public ICollection<Ingredient> ingredients { get; set; }
    }
}