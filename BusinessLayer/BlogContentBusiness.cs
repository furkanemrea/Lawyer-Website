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
    public class BlogContentBusiness : BaseBusiness, IBlogContentBusiness
    {
        private readonly ISystemUserBusiness _systemUserBusiness;
        public BlogContentBusiness(LawyersitedbContext context, ISystemUserBusiness systemUserBusiness) : base(context)
        {
            _systemUserBusiness = systemUserBusiness;
        }

        public async Task<EntityResponse<List<BlogContents>>> BlogContentListByBlog(long blogId)
        {
            EntityResponse<List<BlogContents>> entityResponse = new();
            try
            {
                List<BlogContents> blogContents = await _context.BlogContents.Where(x => x.BlogId==blogId && x.RowStatusId == RowStatusValues.RowStatusActive).ToListAsync();
                entityResponse.RelatedEntity = blogContents;
                entityResponse.Status = EntityResponseStatus.Success;
            }
            catch (Exception ex)
            {
                entityResponse.Status = EntityResponseStatus.Error;
            }
            return entityResponse;
        }
        public async Task<EntityResponse<BlogContents>> CreateBlogContent(BlogContents blogContents)
        {
            EntityResponse<BlogContents> entityResponse = new();
            try
            {
                blogContents.RowStatusId = RowStatusValues.RowStatusActive;
                blogContents.CreatedById = _systemUserBusiness.CurrentUser().Id;
                await _context.BlogContents.AddAsync(blogContents);
                _context.SaveChanges();
                entityResponse.RelatedEntity = blogContents;
                entityResponse.Status = EntityResponseStatus.Success;
            }
            catch (Exception ex)
            {
                entityResponse.Status = EntityResponseStatus.Error;
            }
            return entityResponse;
        }
        public async Task<EntityResponse<BlogContents>> DeleteContent(long contentId)
        {
            EntityResponse<BlogContents> response = new();
            try
            {
                var content = await _context.BlogContents.FindAsync(contentId);
                if (content != null)
                {
                    content.RowStatusId = RowStatusValues.RowStatusDeleted;
                    await _context.SaveChangesAsync();
                    response.Status = EntityResponseStatus.Success;
                    return response;
                }
                response.Status = EntityResponseStatus.Empty;
                return response;

            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Status = EntityResponseStatus.Error;
            }
            return response;
        }
    }
}
