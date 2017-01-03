using NgCooking.DAL;
using NgCooking.Models;
using NgCooking.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Helpers;
using System.Web.Mvc;

namespace NgCooking.Controllers
{
    public class RecettesController : Controller
    {
        private NgCookingContext db = new NgCookingContext();
        private IDal dal;

        public RecettesController() : this(new Dal())
        {

        }

        public RecettesController(IDal dalIoc)
        {
            dal = dalIoc;
        }


        // GET: Recettes
        public ActionResult Index(string searchname, string selectordre, string searchingredient, int? mincal, int? maxcal, int? page)
        {
            List<Recette> LstRct = searchname == null || searchname == "" ? dal.ObtenirTousLesRecettes() : dal.ObtenirLesRecettesContenant(searchname);

            if (maxcal != null && mincal != null)
            {
                if (LstRct.Count != 0)
                {
                    int maxnorm = (int)maxcal;
                    int minnorm = (int)mincal;
                    if (maxcal != 0 && mincal != 0)
                    {
                        LstRct = dal.ObtenirLesRecettesEntreMinEtMax(LstRct, minnorm <= maxnorm ? minnorm : maxnorm, minnorm <= maxnorm ? maxnorm : minnorm);
                    }
                    else if (maxcal != 0)
                    {
                        LstRct = dal.ObtenirLesRecettesInfMax(LstRct, maxnorm);
                    }
                    else if (mincal != 0)
                    {
                        LstRct = dal.ObtenirLesRecettesInfMax(LstRct, maxnorm);
                    }
                }
            }

            if (LstRct.Count != 0)
            {
                switch (selectordre)
                {
                    case "za":
                        LstRct = dal.ObtenirLesRecettesTrierDesc(LstRct, "name");
                        break;
                    case "new":
                        LstRct = dal.ObtenirLesRecettesTrierDesc(LstRct, "creation");
                        break;
                    case "old":
                        LstRct = dal.ObtenirLesRecettesTrierAsc(LstRct, "creation");
                        break;
                    case "best":
                        LstRct = dal.ObtenirLesRecettesTrierDesc(LstRct, "average");
                        break;
                    case "worst":
                        LstRct = dal.ObtenirLesRecettesTrierAsc(LstRct, "average");
                        break;
                    case "cal":
                        LstRct = dal.ObtenirLesRecettesTrierAsc(LstRct, "calories");
                        break;
                    case "cal_desc":
                        LstRct = dal.ObtenirLesRecettesTrierDesc(LstRct, "calories");
                        break;
                    default:
                        LstRct = dal.ObtenirLesRecettesTrierAsc(LstRct, "name");
                        break;
                }
            }
            ViewBag.SearchName = searchname == null ? "" : searchname;
            ViewBag.SelectOrdre = selectordre == null || selectordre == "" ? "all" : selectordre;
            ViewBag.SearchIngredient = searchingredient == null ? "" : searchingredient;
            ViewBag.MinCal = (mincal ?? 0);
            ViewBag.MaxCal = (maxcal ?? 0);
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(LstRct.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public ActionResult Create()
        {
            RecettesViewModel Recette = new RecettesViewModel();
            Recette.ListeDesCategories = dal.ObtientToutsLesCategoriesPlusAll();
            Recette.ListeDesIngredients = dal.ObtientToutsLesIngredients();
            return View(Recette);
        }

        [HttpPost]
        public ActionResult Create(RecettesViewModel Recette)
        {
            if(ModelState.IsValid)
            {
                string idfinal = Recette.NouvelleRecette.name.ToLower().Replace(' ', '_').Replace('\'', '_').Trim();
                if(dal.ObtenirUneRecetteParId(idfinal) == null)
                {
                    bool ingOk = true;
                    List<Ingredient> IngredientPossible = new List<Ingredient>();
                    foreach (string ing in Recette.ComposantDeLaRecette.Split(';'))
                    {
                        if (ing == "") continue;
                        else
                        {
                            Ingredient waitToAdd = dal.ObtenirUnIngredientParSonId(ing);
                            if (waitToAdd == null)
                            {
                                ingOk = false;
                                break;
                            }
                            else
                            {
                                IngredientPossible.Add(waitToAdd);
                            }
                        }
                    }

                    if (!ingOk)
                    {
                        return Json(new { success = false, responseText = "L'un des ingrédients de la recette est partie en cacahouette." });
                    }
                    else
                    {
                        if (IngredientPossible.Count >= 3 && IngredientPossible.Count <= 10)
                        {
                            Recette.NouvelleRecette.id = idfinal;
                            Recette.NouvelleRecette.ChiefId = Convert.ToInt16(System.Web.HttpContext.Current.User.Identity.Name);
                            Recette.NouvelleRecette.chief = dal.UserFind(Recette.NouvelleRecette.ChiefId);
                            string NomImg = idfinal + ".jpg";
                            string dst = Server.MapPath("/Resources/recettes/");
                            if (Recette.NouvelleRecette.picture != null && Recette.NouvelleRecette.picture != "")
                            {
                                string route = Server.MapPath(Recette.NouvelleRecette.picture);
                                System.IO.File.Move(route, dst + NomImg);
                            }
                            else
                            {
                                string route = Server.MapPath("~/Resources/recette_placeholder.jpg");
                                System.IO.File.Copy(route, dst + NomImg);
                            }
                            Recette.NouvelleRecette.picture = NomImg;
                            Recette.NouvelleRecette.preparation = Recette.NouvelleRecette.preparation.Replace("\r\n", "<br />");
                            if (dal.SauvegarderLaRecette(Recette.NouvelleRecette))
                            {
                                List<IngredientRecette> lstIngRct = new List<IngredientRecette>();
                                foreach (Ingredient ing in IngredientPossible)
                                {
                                    lstIngRct.Add(new IngredientRecette() { recetteId = idfinal, recette = Recette.NouvelleRecette, ingredientId = ing.id, ingredient = ing, quantite = "100" });
                                }
                                
                                if (dal.SauvegarderLesIngredientsDUneRecette(lstIngRct))
                                {
                                    return Json(new { success = true });
                                }
                                else
                                {

                                    return Json(new { success = false, responseText = "Les ingrédients de la recette n'ont pu être enregistré, réessayé plutard." });
                                }
                            }
                            else
                            {
                                return Json(new { success = false, responseText = "La recette n'a pu être enregistré, réessayé plutard." });
                            }
                        }
                        else
                        {
                            return Json(new { success = false, responseText = "Il faut entre 3 et 10 ingrédients par recette." });
                        }
                    }
                    
                    
                }
                else
                {
                    return Json(new { success = false, responseText = "Une recette avec ce nom existe déjà" });
                }
            }
            Recette.ListeDesCategories = dal.ObtientToutsLesCategoriesPlusAll();
            Recette.ListeDesIngredients = dal.ObtientToutsLesIngredients();
            //if (ids != null)
            //{
            //    foreach (string id in ids)
            //    {
            //        Recette.NouvelleRecette.ingredientRecettes.Add(new IngredientRecette() { ingredientId = id, ingredient = dal.ObtenirUnIngredientParSonId(id) });
            //    }
            //}
            return View(Recette);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadImg()
        {
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("/Resources/temp/MVC_") + _imgname + _ext;
                    _imgname = "MVC_" + _imgname + _ext;

                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    // Saving Image in Original Mode
                    pic.SaveAs(path);

                    // resizing image
                    MemoryStream ms = new MemoryStream();
                    WebImage img = new WebImage(_comPath);

                    if (img.Width > 200)
                        img.Resize(200, 200);
                    img.Save(_comPath);
                    // end resize
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public ActionResult UploadImg(HttpPostedFileBase file)
        //{
        //    return Json("toto");
        //}

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recette recette = db.Recettes.Find(id);
            if (recette == null)
            {
                return HttpNotFound();
            }
            DetailsRecettesViewModel details = new DetailsRecettesViewModel();
            //recette.preparation = recette.preparation.Replace("<br />",Environment.NewLine);

            details.LaRecette = recette;
            details.LesCommentaires = dal.ObtenirLesCommentairesDuneRecette(recette.id);
            details.LesIngredients = dal.ObtenirLesIngredientsDuneRecette(recette.id);
            details.LeCommentaire = new CommunauteRecette();
            details.LeCommentaire.recetteId = recette.id;

            return View(details);
        }

        [HttpPost]
        public ActionResult ObtenirCatIng(string idCat)
        {
            return Json(new SelectList(idCat == "all" ? dal.ObtientToutsLesIngredients() : dal.ObtenirLesIngredientsDUneCat(idCat), "Id", "Name"));
        }

        [HttpPost]
        public ActionResult ObtenirNbreCal(List<string> ids)
        {
            return Json(dal.ObtenirLeTotalDeCalorie(ids));
        }

        [ChildActionOnly]
        public PartialViewResult Vignette(string id, Recette recette)
        {
            if (id == null && recette == null)
            {
                ViewBag.Error = "Recette non identifiable";
            }
            if (id != null && recette == null)
            {
                recette = db.Recettes.Find(id);
            }
            if (recette == null)
            {
                ViewBag.Error = "Recette Inconnu";
            }
            return PartialView(recette);
        }

        [ChildActionOnly]
        public PartialViewResult BandeauRecettes(string titre,string col)
        {
            ViewData["Title"] = titre;
            List<Recette> lstRet = dal.ObtenirTousLesRecettes();
            switch(col)
            {
                case "creation":
                    lstRet = dal.ObtenirLesRecettesTrierDesc(col);
                    break;
                default:
                    lstRet = dal.ObtenirLesRecettesTrierDesc("average");
                    break;

            }
            return PartialView(lstRet);
        }

        public PartialViewResult HeaderRecette()
        {
            ViewBag.CompteRecette = dal.ObtenirTousLesRecettes().Count();
            return PartialView();
        }
    }
}