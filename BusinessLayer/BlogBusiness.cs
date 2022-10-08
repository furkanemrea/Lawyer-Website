using CommonLibrary;
using EntityLayer.EntityLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BlogBusiness :BaseBusiness,IBlogBusiness
    {
        private readonly ISystemUserBusiness _systemUserBusiness;
        public BlogBusiness(LawyersitedbContext context, ISystemUserBusiness systemUserBusiness) : base(context)
        {
            _systemUserBusiness = systemUserBusiness;
        }
        public async Task<EntityResponse<Blogs>> CreateBlog(Blogs blogs)
        {
            EntityResponse<Blogs> entityResponse = new();
            try
            {
                SystemUsers systemUsers = _systemUserBusiness.CurrentUser();
                blogs.CreatedById = systemUsers.Id;
                blogs.CreatedOn = DateTime.Now;
                blogs.RowStatusId = RowStatusValues.RowStatusActive;
                await _context.Blogs.AddAsync(blogs);
                _context.SaveChanges();
                entityResponse.Status = EntityResponseStatus.Success;
            }
            catch (Exception ex)
            {
                entityResponse.Status = EntityResponseStatus.Error;
            }
            return entityResponse;
        }

        public List<Blogs> GetBlogList()
        {
            return _context.Blogs
                .Include(x=>x.BlogContents)
                .Include(x=>x.CreatedBy)
                .Where(x => x.RowStatusId == RowStatusValues.RowStatusActive ).ToList();
        }
 
    }
}
