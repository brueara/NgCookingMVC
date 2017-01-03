using NgCooking.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NgCooking.DAL
{
    public class Dal : IDal
    {
        private NgCookingContext bdd;

        public Dal()
        {
            bdd = new NgCookingContext();
        }
        public void Dispose()
        {
            bdd.Dispose();
        }

        #region Categorie

        public List<Categorie> ObtientToutesLesCategories()
        {
            return bdd.Categories.ToList();
        }
        public List<Categorie> ObtientToutsLesCategoriesPlusAll()
        {
            List<Categorie> cat = new List<Categorie>();
            cat.Add(new Categorie { id = "all", nameToDisplay = "Toutes les catégories" });
            cat.AddRange(ObtientToutesLesCategories());
            return cat.ToList();
        }
        #endregion

        #region Ingredient
        public List<Ingredient> ObtientToutsLesIngredients()
        {
            return bdd.Ingredients.OrderBy(p => p.name).ToList();
        }

        public List<Ingredient> ObtenirLesIngredientsDuneRecette(string id)
        {
            List<IngredientRecette> Liaisons = bdd.IngredientReccettes.Where(p => p.recetteId == id).ToList();
            List<Ingredient> IngredientRecette = new List<Ingredient>();
            foreach (IngredientRecette lien in Liaisons)
            {
                IngredientRecette.AddRange(bdd.Ingredients.Where(p => p.id == lien.ingredientId));
            }

            return IngredientRecette;
        }

        public IPagedList<Ingredient> ObtientToutsLesIngredients(int pageNumber, int pageSize)
        {
            return ObtientToutsLesIngredients().ToPagedList(pageNumber, pageSize);
        }

        public IPagedList<Ingredient> ObtientToutsLesIngredients(List<Ingredient> ing, int pageNumber, int pageSize)
        {
            return ing.ToPagedList(pageNumber, pageSize);
        }

        public int IngredientCalorifique()
        {
            int toto = ObtientToutsLesIngredients().OrderByDescending(p => p.calories).Select(p => p.calories).FirstOrDefault();

            return toto == 0 ? 1 : toto;
        }

        public int IngredientCalorifique(List<Ingredient> ing)
        {
            int toto = ing.OrderByDescending(p => p.calories).Select(p => p.calories).FirstOrDefault();

            return toto == 0 ? 1 : toto;
        }

        public List<Ingredient> ObtenirLesIngredientsDUneCat(string cat)
        {
            return ObtientToutsLesIngredients().Where(p => p.CategoryId == cat).ToList();
        }

        public List<Ingredient> ObtenirLesIngredientsContenant(List<Ingredient> ing, string likeword)
        {
            return ing.Where(p => p.name.ToLower().Contains(likeword.ToLower())).ToList();
        }
        public List<Ingredient> ObtenirLesIngredientEntreMinEtMax(List<Ingredient> ing, int min, int max)
        {
            return ObtenirLesIngredientsInfMax(ObtenirLesIngredientsSupMin(ing, min), max).ToList();
        }
        public List<Ingredient> ObtenirLesIngredientsInfMax(List<Ingredient> ing, int max)
        {
            return ing.Where(p => p.calories <= max).ToList();
        }

        public List<Ingredient> ObtenirLesIngredientsSupMin(List<Ingredient> ing, int min)
        {
            return ing.Where(p => p.calories >= min).ToList();
        }

        public int ObtenirLeTotalDeCalorie(List<string> ids)
        {
            if (ids == null || ids.Count() == 0)
                return 0;
            else
            {
                return bdd.Ingredients.Where(p => ids.Contains(p.id)).Select(p => p.calories).Sum();
            }
        }

        public Ingredient ObtenirUnIngredientParSonId(string id)
        {
            return bdd.Ingredients.Where(p => p.id == id).FirstOrDefault();
        }
        #endregion

        #region Recette
        public List<Recette> ObtenirLesRecettesDuChef(int? id)
        {
            return bdd.Recettes.Where(p => p.chief.id == id).ToList();
        }

        public List<Recette> ObtenirTousLesRecettes()
        {
            return bdd.Recettes.ToList();
        }
        public List<Recette> ObtenirLesRecettesContenant(string likeword)
        {
            return bdd.Recettes.Where(p => p.name.ToLower().Contains(likeword.ToLower())).ToList();
        }

        public List<Recette> ObtenirLesRecettesEntreMinEtMax(List<Recette> ing, int min, int max)
        {
            return ObtenirLesRecettesInfMax(ObtenirLesRecettesSupMin(ing, min), max).ToList();
        }
        public List<Recette> ObtenirLesRecettesInfMax(List<Recette> ing, int max)
        {
            return ing.Where(p => p.calories <= max).ToList();
        }

        public List<Recette> ObtenirLesRecettesSupMin(List<Recette> ing, int min)
        {
            return ing.Where(p => p.calories >= min).ToList();
        }

        public List<Recette> ObtenirLesRecettesTrierAsc(List<Recette> ing, string field)
        {
            var fieldInfo = typeof(Recette).GetProperty(field);
            return ing.OrderBy(x => fieldInfo.GetValue(x, null)).ToList();
        }
        public List<Recette> ObtenirLesRecettesTrierAsc(string field)
        {
            List<Recette> lstret = ObtenirLesRecettesTrierAsc(ObtenirTousLesRecettes(), field);
            return lstret.Take(4).ToList();
        }

        public List<Recette> ObtenirLesRecettesTrierDesc(List<Recette> ing, string field)
        {
            var fieldInfo = typeof(Recette).GetProperty(field);
            return ing.OrderByDescending(x => fieldInfo.GetValue(x, null)).ToList();
        }

        public List<Recette> ObtenirLesRecettesTrierDesc(string field)
        {
            List<Recette> lstret = ObtenirLesRecettesTrierDesc(ObtenirTousLesRecettes(), field);
            return lstret.Take(4).ToList();

        }

        public Recette ObtenirUneRecetteParId(string idRecette)
        {
            return bdd.Recettes.Where(p => p.id == idRecette).FirstOrDefault();
        }

        public bool MettreAJourlaNoteDeLaRecette(string idRecette)
        {
            try
            {
                var recette = bdd.Recettes.Where(p => p.id == idRecette).FirstOrDefault();
                recette.average = bdd.CommunauteRecettes.Where(p => p.recetteId == idRecette).Select(p => p.mark).Average();
                bdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool SauvegarderLaRecette(Recette newRecette)
        {
            try
            {
                bdd.Recettes.Add(newRecette);
                bdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool SauvegarderLesIngredientsDUneRecette(List<IngredientRecette> Compositions)
        {
            try
            {
                bdd.IngredientReccettes.AddRange(Compositions);
                bdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        #endregion

        #region Communaute
        public Communaute UserFind(int? id)
        {
            return bdd.Communautes.Where(p => p.id == id).FirstOrDefault();
        }
        public Communaute UserFind(string login, string password)
        {
            return bdd.Communautes.Where(p => p.email == login && p.password == password).FirstOrDefault();
        }

        public bool EmailExist(string email)
        {
            return bdd.Communautes.Where(p => p.email == email).Any();
        }

        public int CreateCount(ViewModels.CreateViewModel user)
        {
            var newUser = new Communaute { firstname = user.firstname, surname = user.surname, email = user.email, password = user.password, city = user.city };
            bdd.Communautes.Add(newUser);
            bdd.SaveChanges();
            return newUser.id;
        }

        public List<Communaute> ObtenirTousLesUtilisateurs()
        {
            return bdd.Communautes.ToList();
        }

        public List<Communaute> ObtenirLesCommunautesTrierAsc(List<Communaute> ing)
        {
            return ing.OrderBy(x => x.firstname).ThenBy(x => x.surname).ToList();
        }

        public List<Communaute> ObtenirLesCommunautesTrierAsc(List<Communaute> ing, string field)
        {
            var fieldInfo = typeof(Communaute).GetProperty(field);
            return ing.OrderBy(x => fieldInfo.GetValue(x, null)).ThenBy(x => x.firstname).ThenBy(x => x.surname).ToList();
        }
        public List<Communaute> ObtenirLesCommunautesTrierDesc(List<Communaute> ing)
        {
            return ing.OrderByDescending(x => x.firstname).ThenByDescending(x => x.firstname).ToList();
        }
        public List<Communaute> ObtenirLesCommunautesTrierDesc(List<Communaute> ing, string field)
        {
            var fieldInfo = typeof(Communaute).GetProperty(field);
            return ing.OrderByDescending(x => fieldInfo.GetValue(x, null)).ThenByDescending(x => x.firstname).ThenByDescending(x => x.surname).ToList();
        }

        public List<Communaute> ObtenirLesCommunautesProdAsc(List<Communaute> ing)
        {
            return ing.OrderBy(x => x.recettes.Count()).ThenBy(x => x.firstname).ThenBy(x => x.surname).ToList();
        }

        public List<Communaute> ObtenirLesCommunautesProdDesc(List<Communaute> ing)
        {
            return ing.OrderByDescending(x => x.recettes.Count()).ThenByDescending(x => x.firstname).ThenByDescending(x => x.surname).ToList();
        }

        public bool AjouterUnUtilisateur(Communaute user)
        {
            try
            {
                bdd.Communautes.Add(user);
                bdd.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool SupprimerUtilisateur(int id)
        {
            try
            {
                bdd.Communautes.Remove(UserFind(id));
                bdd.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool MiseAJourUtilisateur(Communaute user)
        {
            try
            {
                bdd.Entry(user).State = EntityState.Modified;
                bdd.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool MettreAJourlaNoteDuChef(int idChef)
        {
            if (idChef <= 0) return false;
            try
            {
                var chef = bdd.Communautes.Where(p => p.id == idChef).FirstOrDefault();
                chef.level = 3 * bdd.Recettes.Where(p => p.ChiefId == idChef).Select(p => p.average).Average() / 5;
                bdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool MettreAJourlaNoteDuChef(string idrecette)
        {
            return MettreAJourlaNoteDuChef(bdd.Recettes.Where(p => p.id == idrecette).Select(p => p.ChiefId).FirstOrDefault());
        }

        public int ObtenirLAgeDuChef(int idChef)
        {
            DateTime jour = DateTime.Now;
            DateTime anniv = UserFind(idChef).birth;
            int age = jour.Year - anniv.Year;
            if (jour < anniv.AddYears(age)) age--;

            return age;
        }

        public string ObtenirLeNiveauDuChef(int idChef)
        {
            string niveau = "";
            double level = UserFind(idChef).level;
            if (level < 1)
            {
                niveau = "NOVICE";
            }
            else if (level < 2)
            {
                niveau = "CONFIRMÉ";
            }
            else
            {
                niveau = "EXPERT";
            }


            return niveau;
        }
        #endregion

        #region Commentaire
        public bool ADejaFaitUnCommentaire(int idUser, string idRecette)
        {
            return bdd.CommunauteRecettes.Where(p => p.communauteId == idUser && p.recetteId == idRecette).Any();
        }

        public bool EstLeCreateruDeLaRecette(int idUser, string idRecette)
        {
            return bdd.Recettes.Where(p => p.ChiefId == idUser && p.id == idRecette).Any();
        }

        public List<CommunauteRecette> ObtenirLesCommentairesDuneRecette(string id)
        {
            return bdd.CommunauteRecettes.Where(p => p.recetteId == id).ToList();
        }

        public bool AjouterUnCommentaire(CommunauteRecette newCom)
        {
            try
            {
                bdd.CommunauteRecettes.Add(newCom);
                bdd.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int SupprimerUnComentaire(CommunauteRecette com)
        {
            bdd.CommunauteRecettes.Remove(com);
            return bdd.SaveChanges();
        }


        #endregion
    }

}