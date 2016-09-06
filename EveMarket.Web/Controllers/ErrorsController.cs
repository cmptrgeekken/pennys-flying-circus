using System.Web.Mvc;

namespace EveMarket.Web.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult NotFound()
        {
            var model = Request?.Url?.PathAndQuery;

            if (!Request.IsAjaxRequest())
            {
                return View("NotFound", model);
            }

            return PartialView("_NotFound", model);
        }
    }
}