using CommonLibrary;
using EntityLayer.EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBlogBusiness
    {
        List<Blogs> GetBlogList();

        Task<EntityResponse<Blogs>> CreateBlog(Blogs blogs);
    }
}
