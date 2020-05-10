using System.Web.Mvc;

namespace SerwisGitar.Controllers
{
    public class CustomInstrumentsController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }
    }
}