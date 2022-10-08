using BusinessLayer;
using EntityLayer.DTO.SiteModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LawyerSite.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogBusiness _blogBusiness;
        private readonly IBlogContentBusiness _blogContentBusiness;
        public BlogController(IBlogBusiness blogBusiness, IBlogContentBusiness blogContentBusiness)
        {
            _blogBusiness=blogBusiness;
            _blogContentBusiness=blogContentBusiness;
        }

        public async Task<IActionResult> Blogs()
        {
            BlogPageViewModel blogPageViewModel = new();
            blogPageViewModel.Blogs = _blogBusiness.GetBlogList();
            return await Task.FromResult(View(blogPageViewModel));
        }
        public async Task<IActionResult> Detail(long id)
        {
            BlogDetailPageViewModel blogDetailPageViewModel = new();
            blogDetailPageViewModel.BlogContents = (await _blogContentBusiness.BlogContentListByBlog(id)).RelatedEntity;
            return View(blogDetailPageViewModel);
        }
    }
}
