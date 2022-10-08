using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class EntityResponse<TEntity> where TEntity : class
    {
        public Exception Exception { get; set; }
        public EntityResponseStatus Status { get; set; }
        public string Message { get; set; }
        public TEntity RelatedEntity { get; set; }

        public EntityResponse()
        {
            this.Status = EntityResponseStatus.Empty;
        }
        public bool EntityIsNull()
        {
            return !EqualityComparer<TEntity>.Default.Equals(RelatedEntity, null) && RelatedEntity != null;
        }
        public bool EntityIsNotNull()
        {
            return !EntityIsNull();
        }
        public bool HasError()
        {
            return this.Exception != null;
        }
        public bool IsSuccess()
        {
            return this.Status == EntityResponseStatus.Success;
        }
        public static EntityResponse<TEntity> Empty()
        {
            return new EntityResponse<TEntity>()
            {
                Status = EntityResponseStatus.Empty
            };
        }
    }
}
