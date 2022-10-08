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
    public class BulletinBusiness : BaseBusiness, IBulletinBusiness
    {
        private readonly ISystemUserBusiness _systemUserBusiness;
        public BulletinBusiness(LawyersitedbContext context, ISystemUserBusiness systemUserBusiness) : base(context)
        {
            _systemUserBusiness = systemUserBusiness;
        }

        public async Task<EntityResponse<Bulletins>> CreateBulletin(Bulletins bulletins)
        {
            EntityResponse<Bulletins> entityResponse = new();
            try
            {
                SystemUsers systemUsers = _systemUserBusiness.CurrentUser();
                bulletins.CreatedById = systemUsers.Id;
                bulletins.RowStatusId = RowStatusValues.RowStatusActive;
                await _context.Bulletins.AddAsync(bulletins);
                await _context.SaveChangesAsync();
                entityResponse.Status = EntityResponseStatus.Success;
            }
            catch (Exception ex)
            {
                entityResponse.Status = EntityResponseStatus.Error;
            }
            return entityResponse;
        }
        public async Task<EntityResponse<List<Bulletins>>> ListBulletins()
        {
            EntityResponse<List<Bulletins>> entityResponse = new();
            try
            {
                SystemUsers systemUsers = _systemUserBusiness.CurrentUser();
                List<Bulletins> bulletins= await _context.Bulletins.ToListAsync();
                entityResponse.RelatedEntity = bulletins;
                entityResponse.Status = EntityResponseStatus.Success;
            }
            catch (Exception ex)
            {
                entityResponse.Status = EntityResponseStatus.Error;
            }
            return entityResponse;
        }
    }
}
