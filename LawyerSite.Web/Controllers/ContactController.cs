using Microsoft.AspNetCore.Mvc;

namespace LawyerSite.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
