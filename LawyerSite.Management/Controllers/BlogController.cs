using BusinessLayer;
using CommonLibrary;
using EntityLayer.DTO;
using EntityLayer.EntityLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerSite.Management.Controllers
{
    public class BlogController: Controller
    {
        private readonly IBlogBusiness _blogBusiness;
        private readonly IBlogContentBusiness _blogContentBusiness;

        public BlogController(IBlogBusiness blogBusiness, IBlogContentBusiness blogContentBusiness)
        {
            _blogBusiness = blogBusiness;
            _blogContentBusiness = blogContentBusiness;
        }
        public async Task<IActionResult> List()
        {
            await Task.Delay(0);
            return View(_blogBusiness.GetBlogList());
        }
        public async Task<IActionResult> Create()
        {
            await Task.Delay(0);
            return View();
        }
        

        public async Task<EntityResponse<Blogs>> CreateBlog(Blogs blogs)
        {
            return await _blogBusiness.CreateBlog(blogs);
        }
        public async Task<EntityResponse<BlogContents>> CreateBlogContent(BlogContents blogContents)
        {
            return await _blogContentBusiness.CreateBlogContent(blogContents);
        }

        public async Task<EntityResponse<BlogContents>> DeleteContent(long contentId)
        {
            return await _blogContentBusiness.DeleteContent(contentId);
        }
        public async Task<IActionResult> Detail(long id)
        {
            BlogContentDetailViewModel blogContentDetailViewModel = new()
            {
                BlogContent= (await _blogContentBusiness.BlogContentListByBlog(id)).RelatedEntity,
                BlogId=id
            };
            return View(blogContentDetailViewModel);
        }
    }
}
