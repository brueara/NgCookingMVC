using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NgCooking.Models
{
    public class Recette
    {
        [Key]
        [StringLength(50, ErrorMessage = "C'est plus une recettes que tu nous fait, mais un menu complet(50 caractères max)")]
        public string id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "C'est plus une recettes que tu nous fait, mais un menu complet(50 caractères max)")]
        public string name { get; set; }
        public bool isAvailable { get; set; } = true;
        [DataType(DataType.ImageUrl)]
        public string picture { get; set; }
        public int calories { get; set; } = 0;
        [Required]
        [MinLength(30, ErrorMessage = "C'est une recette que tu écris, pas une note sur un coin de table.(30 caractères min)")]
        //[MaxLength(500, ErrorMessage = "C'est une recette que tu écris, pas un roman.(500 caractères max)")]
        [Column(TypeName = "ntext")]
        public string preparation { get; set; }
        [Range(0, 5)]
        public double average { get; set; } = 0;

        public DateTime creation { get; set; } = DateTime.Now;

        public virtual ICollection<CommunauteRecette> comments { get; set; }

        public int ChiefId { get; set; }
        public virtual Communaute chief { get; set; }
        public virtual ICollection<IngredientRecette> ingredientRecettes { get; set; }

    }
}