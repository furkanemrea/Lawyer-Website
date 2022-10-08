using CommonLibrary;
using EntityLayer.EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ISystemUserBusiness
    {
        Task<EntityResponse<SystemUsers>> SignIn(string mail, string password);
        SystemUsers CurrentUser();
    }
}
