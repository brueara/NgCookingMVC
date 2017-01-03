using NgCooking.Models;
using PagedList;
using System;
using System.Collections.Generic;

namespace NgCooking.DAL
{
    public interface IDal : IDisposable
    {
        #region Categorie
        List<Categorie> ObtientToutesLesCategories();
        List<Categorie> ObtientToutsLesCategoriesPlusAll();
        #endregion

        #region Ingredient
        List<Ingredient> ObtientToutsLesIngredients();
        IPagedList<Ingredient> ObtientToutsLesIngredients(int pageNumber, int pageSize);
        IPagedList<Ingredient> ObtientToutsLesIngredients(List<Ingredient> ing, int pageNumber, int pageSize);
        List<Ingredient> ObtenirLesIngredientsDuneRecette(string id);
        List<Ingredient> ObtenirLesIngredientsDUneCat(string cat);
        List<Ingredient> ObtenirLesIngredientsContenant(List<Ingredient> ing, string likeword);
        List<Ingredient> ObtenirLesIngredientEntreMinEtMax(List<Ingredient> ing, int min, int max);
        List<Ingredient> ObtenirLesIngredientsInfMax(List<Ingredient> ing, int max);
        List<Ingredient> ObtenirLesIngredientsSupMin(List<Ingredient> ing, int min);
        int IngredientCalorifique();
        int IngredientCalorifique(List<Ingredient> ing);
        int ObtenirLeTotalDeCalorie(List<string> ids);
        Ingredient ObtenirUnIngredientParSonId(string id);
        #endregion

        #region Recette
        List<Recette> ObtenirLesRecettesDuChef(int? id);
        List<Recette> ObtenirTousLesRecettes();
        List<Recette> ObtenirLesRecettesContenant(string likeword);
        List<Recette> ObtenirLesRecettesEntreMinEtMax(List<Recette> ing, int min, int max);
        List<Recette> ObtenirLesRecettesInfMax(List<Recette> ing, int max);
        List<Recette> ObtenirLesRecettesSupMin(List<Recette> ing, int min);
        List<Recette> ObtenirLesRecettesTrierAsc(List<Recette> ing, string field);
        List<Recette> ObtenirLesRecettesTrierAsc(string field);
        List<Recette> ObtenirLesRecettesTrierDesc(List<Recette> ing, string field);
        List<Recette> ObtenirLesRecettesTrierDesc(string field);
        Recette ObtenirUneRecetteParId(string idRecette);
        bool MettreAJourlaNoteDeLaRecette(string idRecette);
        bool SauvegarderLaRecette(Recette newRecette);
        bool SauvegarderLesIngredientsDUneRecette(List<IngredientRecette> Compositions);
        #endregion

        #region Communaute
        Communaute UserFind(int? id);
        Communaute UserFind(string login, string password);
        bool EmailExist(string email);
        int CreateCount(ViewModels.CreateViewModel user);
        List<Communaute> ObtenirTousLesUtilisateurs();
        List<Communaute> ObtenirLesCommunautesTrierAsc(List<Communaute> ing);
        List<Communaute> ObtenirLesCommunautesTrierAsc(List<Communaute> ing, string field);
        List<Communaute> ObtenirLesCommunautesTrierDesc(List<Communaute> ing);
        List<Communaute> ObtenirLesCommunautesTrierDesc(List<Communaute> ing, string field);
        List<Communaute> ObtenirLesCommunautesProdAsc(List<Communaute> ing);
        List<Communaute> ObtenirLesCommunautesProdDesc(List<Communaute> ing);
        bool AjouterUnUtilisateur(Communaute user);
        bool SupprimerUtilisateur(int id);
        bool MiseAJourUtilisateur(Communaute user);
        bool MettreAJourlaNoteDuChef(int idChef);
        bool MettreAJourlaNoteDuChef(string idrecette);
        int ObtenirLAgeDuChef(int idChef);
        string ObtenirLeNiveauDuChef(int idChef);
        #endregion

        #region Commentaire
        List<CommunauteRecette> ObtenirLesCommentairesDuneRecette(string id);
        bool ADejaFaitUnCommentaire(int idUser, string idRecette);
        bool EstLeCreateruDeLaRecette(int idUser, string idRecette);
        bool AjouterUnCommentaire(CommunauteRecette newCom);
        int SupprimerUnComentaire(CommunauteRecette com);
        #endregion
    }
}
