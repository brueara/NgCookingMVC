using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgCooking.Models
{
    public class Communaute
    {
        [Key]
        public int id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\séèàêâç]{1,40}$",
         ErrorMessage = "Caractère non autorisé par nos conventions.")]
        [Display(Name ="Prénom")]
        public string firstname { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\séèàêâç]{1,40}$",
         ErrorMessage = "Caractère non autorisé par nos conventions.")]
        [Display(Name ="Nom de famille")]
        public string surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9-_@#]{8,40}$",
         ErrorMessage = "Caractère non autorisé par nos conventions.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string password { get; set; }
        public double level { get; set; } = 0;
        [Required]
        [StringLength(50)]
        [Display(Name ="Ville")]
        public string city { get; set; }
        [DataType(DataType.ImageUrl)]
        public string picture { get; set; } = "default.jpg";
        [DataType(DataType.Date)]
        [Display(Name = "Date de naissance")]
        public DateTime birth { get; set; } = new DateTime(2000, 01, 01);
        [StringLength(300, ErrorMessage = "Votre biographie ne peut faire plus de 300 caractères.")]
        [Display(Name ="Biographie")]
        public string bio { get; set; } = "C'est ma bio.";

        public virtual ICollection<CommunauteRecette> communauteRecettes { get; set; }
        public virtual ICollection<Recette> recettes { get; set; }
    }
}