using NgCooking.DAL;
using NgCooking.Models;
using NgCooking.ViewModels;
using System;
using System.Web.Mvc;

namespace NgCooking.Controllers
{
    public class CommunautesRecettesController : Controller
    {
        private IDal dal;

        public CommunautesRecettesController() : this(new Dal())
        {

        }

        public CommunautesRecettesController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: CommunautesRecettes
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Commentaire(string id)
        {
            return PartialView(new CommunauteRecetteViewModel { recetteId = id, communauteId = 0 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Commentaire(CommunauteRecetteViewModel newCom)
        {
            if (ModelState.IsValid)
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt16(System.Web.HttpContext.Current.User.Identity.Name);
                }
                catch
                {
                    return Json(new { success = false, responseText = "Vous ne pouvez pas faire de commentaire sans être authentifier." });
                }
                if (!dal.EstLeCreateruDeLaRecette(id, newCom.recetteId))
                {
                    if (!dal.ADejaFaitUnCommentaire(id, newCom.recetteId))
                    {
                        CommunauteRecette AddCom = new CommunauteRecette { recetteId = newCom.recetteId, communauteId = id, comment = newCom.comment, mark = newCom.mark, title = newCom.title, communaute = dal.UserFind(id) };
                        if (dal.AjouterUnCommentaire(AddCom))
                        {
                            if (dal.MettreAJourlaNoteDeLaRecette(newCom.recetteId))
                            {
                                if (dal.MettreAJourlaNoteDuChef(newCom.recetteId))
                                {
                                    return Json(new { success = true, responseText = "Le commentaire a été parfaitement enregistré." });
                                }
                                else
                                {
                                    dal.SupprimerUnComentaire(AddCom);
                                    dal.MettreAJourlaNoteDeLaRecette(newCom.recetteId);
                                    return Json(new { success = false, responseText = "La mise à jours de la note du chef a échoué." });
                                }
                            }
                            else
                            {
                                dal.SupprimerUnComentaire(AddCom);
                                return Json(new { success = false, responseText = "La mise à jours de la note de la recette a échoué." });
                            }
                        }
                        else
                        {
                            return Json(new { success = false, responseText = "L'enregistrement du commentaire a échoué." });
                        }
                    }
                    else
                    {
                        return Json(new { success = false, responseText = "La mise à jours de la note du chef a échoué." });
                    }
                }
                else
                {
                    return Json(new { success = false, responseText = "Vous êtes le créateur de cette recette." });
                }
            }
            else
            {
                return Json(new { success = false, responseText = "Le commentaire n'est pas valide." });
            }
        }

    }
}