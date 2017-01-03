using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgCooking.Models
{
    public class Ingredient
    {
        [Key]
        [Required]
        [StringLength(30, ErrorMessage = "C'est quoi cette aliment qui necessite plus de 30 caractères.")]
        public string id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "C'est quoi cette aliment qui necessite plus de 30 caractères.")]
        [Display(Name ="nom")]
        public string name { get; set; }

        public bool isAvailable { get; set; }
        [DataType(DataType.ImageUrl)]
        public string picture { get; set; }
        public string CategoryId { get; set; }
        [Display(Name = "catégorie")]
        public virtual Categorie category { get; set; }
        public int calories { get; set; }
        public string description { get; set; }

        public virtual ICollection<IngredientRecette> ingredientRecettes { get; set; }
    }
}