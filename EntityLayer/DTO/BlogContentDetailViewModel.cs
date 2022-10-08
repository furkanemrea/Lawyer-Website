using EntityLayer.EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
   public class BlogContentDetailViewModel
    {
        public List<BlogContents> BlogContent{ get; set; }
        public long BlogId { get; set; }
    }
}
