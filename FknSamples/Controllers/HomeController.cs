using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace FknSamples.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var methods = typeof (HomeController).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => !m.IsSpecialName)
                .Where(m => m.DeclaringType == typeof(HomeController))
                .Where(m => m.Name != "Index");
            return View(methods.Select(m => m.Name));
        }

        public ActionResult Formspree()
        {
            ViewBag.Title = "Formspree";
            return View();
        }

    }
}