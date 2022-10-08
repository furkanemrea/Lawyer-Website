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
    public class BulletinController : Controller
    {
        private readonly IBulletinBusiness _bulletinBusiness;
        public BulletinController(IBulletinBusiness bulletinBusiness)
        {
            _bulletinBusiness = bulletinBusiness;
        }
        public IActionResult CreateBulletin()
        {
            return View();
        }
        public async Task<EntityResponse<Bulletins>> CreateNewBulletin(Bulletins bulletins)
        {
            return await _bulletinBusiness.CreateBulletin(bulletins);
        }
        public async Task<IActionResult> ListBulletin()
        {
            return View((await _bulletinBusiness.ListBulletins()).RelatedEntity);
        }
    }
}
