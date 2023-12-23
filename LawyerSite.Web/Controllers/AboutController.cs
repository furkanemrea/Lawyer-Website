using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LawyerSite.Web.Controllers
{
    public class AboutController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }


        public async Task<IActionResult> OnPress()
        {
            return await Task.FromResult(View());
        }
    }
}
 