using CommonLibrary;
using EntityLayer.EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBulletinBusiness
    {
        Task<EntityResponse<Bulletins>> CreateBulletin(Bulletins bulletins);
        Task<EntityResponse<List<Bulletins>>> ListBulletins();
    }
}
