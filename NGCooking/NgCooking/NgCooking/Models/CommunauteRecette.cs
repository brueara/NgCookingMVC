using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NgCooking.Models
{
    public class CommunauteRecette
    {
        [Key, Column(Order = 0)]
        public string recetteId { get; set; }
        [Key, Column(Order = 1)]
        public int communauteId { get; set; }
        public virtual Recette recette { get; set; }
        public virtual Communaute communaute { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Il faut un vrai titre")]
        [MaxLength(50, ErrorMessage = "C'est titre qui est demandé pas le commentaire au complet.")]
        public string title { get; set; }
        [Required]
        [MinLength(20, ErrorMessage = "Un commentaire plus precise ne serait pas de refus.")]
        [MaxLength(400, ErrorMessage = "Un commentaire n'est pas un roman.")]
        public string comment { get; set; }
        [Required]
        [Range(0, 5)]
        public double mark { get; set; }
    }
}