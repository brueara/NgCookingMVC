using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NgCooking.Models
{
    public class IngredientRecette
    {
        [Key, Column(Order = 0)]
        public string recetteId { get; set; }
        [Key, Column(Order = 1)]
        public string  ingredientId { get; set; }
        public virtual Recette recette { get; set; }
        public virtual Ingredient ingredient { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "C'est une quantité qui est souhaité, exemple : 120g")]
        public string quantite { get; set; } = "100gr";
    }
}