using NgCooking.DAL;
using System.Web.Mvc;

namespace NgCooking.Controllers
{
    public class HomeController : Controller
    {
        private IDal dal;
        public HomeController() : this(new Dal())
        {

        }

        public HomeController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}