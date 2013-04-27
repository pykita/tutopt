using System.Web.Mvc;

namespace Tutopt.Controllers
{
    public class GoodsController : Controller
    {
        public GoodsController()
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
