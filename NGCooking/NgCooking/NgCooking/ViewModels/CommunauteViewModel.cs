using NgCooking.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgCooking.ViewModels
{
    public class CreateViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\séèàêâç]{1,40}$",
         ErrorMessage = "Caractère non autorisé par nos conventions.")]
        [Display(Name = "Prénom")]
        public string firstname { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\séèàêâç]{1,40}$",
         ErrorMessage = "Caractère non autorisé par nos conventions.")]
        [Display(Name = "Nom de famille")]
        public string surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string email { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Ville")]
        public string city { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9-_@#]{8,40}$",
         ErrorMessage = "Caractère non autorisé par nos conventions.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation mot de passe")]
        [RegularExpression(@"^[a-zA-Z0-9-_@#]{8,40}$",
         ErrorMessage = "Caractère non autorisé par nos conventions.")]
        [Compare("password", ErrorMessage = "Le mot de passe n'est pas identique.")]
        public string confirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9-_@#]{8,40}$",
         ErrorMessage = "Caractère non autorisé par nos conventions.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string password { get; set; }
    }

    public class ChangedPasswordViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9-_@#]{8,40}$",
         ErrorMessage = "Caractère non autorisé par nos conventions.")]
        [DataType(DataType.Password)]
        [Display(Name = "Ancien mot de passe")]
        public string oldpassword { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9-_@#]{8,40}$",
         ErrorMessage = "Caractère non autorisé par nos conventions.")]
        [DataType(DataType.Password)]
        [Display(Name = "Nouveau mot de passe")]
        public string newpassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmation mot de passe")]
        [Compare("newpassword", ErrorMessage = "Le mot de passe n'est pas identique.")]
        public string confirmPassword { get; set; }
    }

    public class FicheChefViewModel
    {
        public Communaute Chef { get; set; }
        public List<Recette> RecetteDuChef { get; set; }
    }
}