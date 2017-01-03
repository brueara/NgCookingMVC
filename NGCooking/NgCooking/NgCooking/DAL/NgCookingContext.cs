using NgCooking.Models;
using System.Data.Entity;


namespace NgCooking.DAL
{
    public class NgCookingContext : DbContext
    {
        public NgCookingContext() : base("NgCookingContext")
        {

        }

        public DbSet<Communaute> Communautes { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recette> Recettes { get; set; }
        public DbSet<IngredientRecette> IngredientReccettes { get; set; }
        public DbSet<CommunauteRecette> CommunauteRecettes { get; set; }

    }
}