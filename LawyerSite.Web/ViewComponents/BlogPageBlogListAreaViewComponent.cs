using BusinessLayer;
using CommonLibrary;
using EntityLayer.DTO.SiteModels;
using EntityLayer.EntityLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawyerSite.Web.ViewComponents
{
    public class BlogPageBlogListAreaViewComponent:ViewComponent
    {
        private readonly IBlogContentBusiness _blogContentBusiness;

        public BlogPageBlogListAreaViewComponent(IBlogContentBusiness blogContentBusiness)
        {
            _blogContentBusiness=blogContentBusiness;
        }

        public async Task<IViewComponentResult> InvokeAsync(long blogId)
        {
            EntityResponse<List<BlogContents>>  blogContentResult = await _blogContentBusiness.BlogContentListByBlog(blogId);
            BlogPageBlogContentsViewComponentModel viewModel = new();
            viewModel.BlogContents = blogContentResult.RelatedEntity;
            return await Task.FromResult(View(viewModel));
        }
    }
}
