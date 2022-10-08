using CommonLibrary;
using EntityLayer.EntityLibrary;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerSite.Management.Sessions
{
    public class SessionHelper
    {
        public SystemUsers GetSessionUser()
        {
            HttpContextAccessor _httpContextAccessor = new();
            string userCookie = _httpContextAccessor.HttpContext.Request.Cookies[LawyerConstants.CookieConstant.UserCookieName];
            SystemUsers user = JsonConvert.DeserializeObject<SystemUsers>(userCookie);
            return user;
        }
    }
}
