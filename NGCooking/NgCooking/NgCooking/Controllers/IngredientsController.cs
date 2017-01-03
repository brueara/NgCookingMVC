using NgCooking.DAL;
using NgCooking.Models;
using NgCooking.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NgCooking.Controllers
{
    public class IngredientsController : Controller
    {
        private IDal dal;

        public IngredientsController() : this(new Dal())
        {

        }

        public IngredientsController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: Ingredients
        public ActionResult Index(string searchname,string selectcat, int? mincal, int? maxcal ,int? page )
        {
            IngredientsViewModel IVM = new IngredientsViewModel();
            IVM.ListeDesCategories = dal.ObtientToutsLesCategoriesPlusAll();
            List<Ingredient> LstIng = selectcat == null || selectcat == "" || selectcat == "all" ? dal.ObtientToutsLesIngredients() : dal.ObtenirLesIngredientsDUneCat(selectcat);            
            if(searchname != null && searchname != "")
            {
                LstIng = dal.ObtenirLesIngredientsContenant(LstIng, searchname);
            }
            if (maxcal != null && mincal != null)
            {
                int maxnorm = (int)maxcal;
                int minnorm = (int)mincal;
                if (maxcal != 0 && mincal != 0)
                {
                    LstIng = dal.ObtenirLesIngredientEntreMinEtMax(LstIng, minnorm <= maxnorm ? minnorm : maxnorm, minnorm <= maxnorm ? maxnorm : minnorm);
                }
                else if (maxcal != 0)
                {
                    LstIng = dal.ObtenirLesIngredientsInfMax(LstIng, maxnorm);
                }
                else if (mincal != 0)
                {
                    LstIng = dal.ObtenirLesIngredientsSupMin(LstIng, minnorm);
                }
            }
            ViewBag.SearchName = searchname;
            ViewBag.CatChoise = selectcat == null || selectcat == "" ? "all" : selectcat;
            ViewBag.MinCal = (mincal ?? 0);
            ViewBag.MaxCal = (maxcal ?? 0);

            IVM.PageNum = (page ?? 1);
            IVM.ListeDesIngredients = dal.ObtientToutsLesIngredients(LstIng,IVM.PageNum, IVM.Affiche);
            IVM.FullCalorie = dal.IngredientCalorifique(LstIng);
            return View(IVM);
        }

        public ActionResult Details(string id)
        {
            Ingredient DetailIngredient = dal.ObtenirUnIngredientParSonId(id);
            return View(DetailIngredient);
        }
    }
}