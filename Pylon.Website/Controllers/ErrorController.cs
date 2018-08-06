using System.Web.Mvc;

namespace Pylon.Website.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult NotFound()
		{
			return View("NotFound");
		}

		public ActionResult HttpError()
		{
			return View("HttpError");
		}
    }
}