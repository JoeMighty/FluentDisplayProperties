using System.Web.Mvc;
using FluentDisplayProperties.Demo.ViewModels;

namespace FluentDisplayProperties.Demo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Example/

        public ActionResult Index()
        {
            return View(new ExampleViewModel());
        }
    }
}
