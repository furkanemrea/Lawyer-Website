using CommonLibrary;
using EntityLayer.EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBlogContentBusiness
    {
        Task<EntityResponse<List<BlogContents>>> BlogContentListByBlog(long blogId);
        Task<EntityResponse<BlogContents>> CreateBlogContent(BlogContents blogContents);
        Task<EntityResponse<BlogContents>> DeleteContent(long contentId);

    }
}
