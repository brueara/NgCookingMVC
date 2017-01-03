using NgCooking.Models;
using PagedList;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgCooking.ViewModels
{
    public class IngredientsViewModel
    {
        //public Ingredient NouvelleIngredient { get; set; }
        public IPagedList<Ingredient> ListeDesIngredients { get; set; }
        //public List<Categorie> ListeDesCategories { get; set; }
        public int FullCalorie { get; set; }

        [Display(Name="Catégories")]
        public List<Categorie> ListeDesCategories { get; set; }
        public int MinCalorie { get; set; }
        public int MaxCalorie { get; set; }
        [Display(Name = "nom")]
        public string PartialIngredient { get; set; }
        public string SelectCat { get; set; }
        public string OldCat { get; set; }
        public int PageNum { get; set; }
        public int Affiche { get; set; } = 4;
    }
}