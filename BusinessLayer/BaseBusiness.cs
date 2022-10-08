using EntityLayer.EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BaseBusiness: IBaseBusiness
    {
        protected readonly LawyersitedbContext _context;
        public BaseBusiness(LawyersitedbContext context)
        {
            _context = context;
        }
    }
}
