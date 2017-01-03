using NgCooking.Models;
using System.Collections.Generic;

namespace NgCooking.ViewModels
{
    public class RecettesViewModel
    {
        public Recette NouvelleRecette { get; set; }
        public List<Ingredient> ListeDesIngredients { get; set; }
        public List<Categorie> ListeDesCategories { get; set; }
        public string ComposantDeLaRecette { get; set; }
    }

    public class DetailsRecettesViewModel
    {
        public Recette LaRecette { get; set; }
        public List<Ingredient> LesIngredients { get; set; }
        public CommunauteRecette LeCommentaire { get; set; }
        public List<CommunauteRecette> LesCommentaires { get; set; }
    }
}