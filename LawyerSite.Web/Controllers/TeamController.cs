using Microsoft.AspNetCore.Mvc;

namespace LawyerSite.Web.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
