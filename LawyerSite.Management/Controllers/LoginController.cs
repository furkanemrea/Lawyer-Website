using BusinessLayer;
using CommonLibrary;
using EntityLayer.EntityLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerSite.Management.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISystemUserBusiness _systemUserBusiness;
        public LoginController(ISystemUserBusiness systemUserBusiness)
        {
            _systemUserBusiness = systemUserBusiness;
        }
        public async Task<IActionResult> SignIn()
        {
         
            return View();
        }
        public async Task<EntityResponse<SystemUsers>> LoginCheck(string mail,string password)
        {
            return await _systemUserBusiness.SignIn(mail, password);
        }
    }
}
