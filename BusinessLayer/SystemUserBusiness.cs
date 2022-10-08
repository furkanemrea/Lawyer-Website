using CommonLibrary;
using EntityLayer.EntityLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BusinessLayer
{
    public class SystemUserBusiness:BaseBusiness, ISystemUserBusiness
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SystemUserBusiness(IHttpContextAccessor httpContextAccessor, LawyersitedbContext context):base(context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public SystemUsers CurrentUser()
        {
            HttpContextAccessor _httpContextAccessor = new();
            string userCookie = _httpContextAccessor.HttpContext.Request.Cookies[LawyerConstants.CookieConstant.UserCookieName];
            SystemUsers user = JsonConvert.DeserializeObject<SystemUsers>(userCookie);
            return user;
        }
        public async Task<EntityResponse<SystemUsers>> SignIn(string mail,string password)
        {
            EntityResponse<SystemUsers> entityResponse = new();
            try
            {

                SystemUsers systemUser = await _context.SystemUsers.Where(x => x.Mail == mail && x.Password == password).FirstOrDefaultAsync();
                if (systemUser is not null)
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Append(LawyerConstants.CookieConstant.UserCookieName, JsonConvert.SerializeObject(systemUser));
                    entityResponse.Status = EntityResponseStatus.Success;
                    entityResponse.RelatedEntity = systemUser;
                    return entityResponse;
                }
                entityResponse.Status = EntityResponseStatus.Empty;
            }
            catch (Exception ex)
            {
                entityResponse.Status = EntityResponseStatus.Error;
            }
            return entityResponse;
        }
    }
}
