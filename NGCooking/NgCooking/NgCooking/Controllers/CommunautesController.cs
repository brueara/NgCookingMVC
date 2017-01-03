using NgCooking.DAL;
using NgCooking.Models;
using NgCooking.ViewModels;
using PagedList;
using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace NgCooking.Controllers
{
    public class CommunautesController : Controller
    {

        private IDal dal;

        public CommunautesController() : this(new Dal())
        {

        }

        public CommunautesController(IDal dalIoc)
        {
            dal = dalIoc;
        }


        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ViewModels.LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Communaute user = dal.UserFind(model.email, model.password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.id.ToString(), true);
                    return RedirectToLocal(returnUrl);
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult CreerCompte()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult CreerCompte(CreateViewModel utilisateur)
        {
            if (ModelState.IsValid)
            {
                if (!dal.EmailExist(utilisateur.email))
                {
                    int id = dal.CreateCount(utilisateur);
                    FormsAuthentication.SetAuthCookie(id.ToString(), false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Ce compte existe déjà.";
                }
            }
            return View(utilisateur);

        }

        // GET: /Communautes/Login

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Communautes
        public ActionResult Index(string ordres, int? page)
        {
            var communautes = dal.ObtenirTousLesUtilisateurs();
             
            switch (ordres)
            {
                case "za":
                    communautes = dal.ObtenirLesCommunautesTrierDesc(communautes);
                    break;
                case "exp":
                    communautes = dal.ObtenirLesCommunautesTrierDesc(communautes, "level");
                    break;
                case "nov":
                    communautes = dal.ObtenirLesCommunautesTrierAsc(communautes, "level");
                    break;
                case "prod":
                    communautes = dal.ObtenirLesCommunautesProdDesc(communautes);
                    break;
                case "prod_desc":
                    communautes = dal.ObtenirLesCommunautesProdAsc(communautes);
                    break;
                default:
                    communautes = dal.ObtenirLesCommunautesTrierAsc(communautes);
                    ordres = "az";
                    break;
            }

            ViewBag.SelectOrdre = ordres;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(communautes.ToPagedList(pageNumber, pageSize));
        }

        [AllowAnonymous]
        // GET: Communautes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Communautes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstname,surname,email,password,level,city,picture,birth,bio")] Communaute communaute)
        {
            if (ModelState.IsValid)
            {
                dal.AjouterUnUtilisateur(communaute);
                return RedirectToAction("Index");
            }

            return View(communaute);
        }

        [Authorize]
        public ActionResult Profil()
        {
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                    return RedirectToAction("Details", new { id = Convert.ToInt16(System.Web.HttpContext.Current.User.Identity.Name) });
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Communaute user = dal.UserFind(id);
            if (user != null)
            {
                FicheChefViewModel fiche = new FicheChefViewModel();
                fiche.Chef = user;
                fiche.RecetteDuChef = dal.ObtenirLesRecettesDuChef(id);
                ViewBag.Age = dal.ObtenirLAgeDuChef(user.id);
                ViewBag.Niveau = dal.ObtenirLeNiveauDuChef(user.id);
                return View(fiche);
            }
            return HttpNotFound();
        }

        // GET: Communautes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                if (FormsAuthentication.FormsCookieName != "")
                {
                    return RedirectToAction("Login", new { returnUrl = "" });
                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Communaute communaute = dal.UserFind(id);
            if (communaute == null)
            {
                return HttpNotFound();
            }
            return View(communaute);
        }

        // POST: Communautes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstname,surname,email,password,confirmPassword,level,city,picture,birth,bio")] Communaute communaute)
        {
            if (ModelState.IsValid)
            {
                dal.MiseAJourUtilisateur(communaute);
                return RedirectToAction("Index");
            }
            return View(communaute);
        }

        // GET: Communautes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Communaute communaute = dal.UserFind(id);
            if (communaute == null)
            {
                return HttpNotFound();
            }
            return View(communaute);
        }

        // POST: Communautes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dal.SupprimerUtilisateur(id);

            return RedirectToAction("Index");
        }

        public ActionResult Disconnect()
        {
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
