using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using GZYC.YZ.IDataAccess;
using GZYC.YZ.Models.EFModel;

namespace GZYC.YZ.DataAccess
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
      where TEntity : class
    {
        private readonly EFModel _dbContext=new EFModel();
        public virtual int Insert(TEntity entity, bool isSave = true)
        {
            EntityState state = _dbContext.Entry(entity).State;
            if (state == EntityState.Detached)
            {
                _dbContext.Entry(entity).State = EntityState.Added;
            }
          //  var count=_dbContext.SaveChanges();
            return isSave ? _dbContext.SaveChanges() : 0;
        }

        public virtual int Insert(IEnumerable<TEntity> entities, bool isSave = true)
        {
            try
            {
                _dbContext.Configuration.AutoDetectChangesEnabled = false;
                
                _dbContext.Set<TEntity>().AddRange(entities);
               return isSave?_dbContext.SaveChanges():0;
               
            }
            finally
            {
                _dbContext.Configuration.AutoDetectChangesEnabled = true;
            }
            
        }

        public virtual int Delete(object id, bool isSave = true)
        {
            TEntity entity = _dbContext.Set<TEntity>().Find(id);
            return entity != null ? Delete(entity, isSave) : 0;
        }

        public virtual int Deletes(List<object> ids, bool isSave = true)
        {
            
            return ids.Sum(p => Delete(p, isSave));
        }

        public virtual int Delete(TEntity entity, bool isSave = true)
        {          
            _dbContext.Entry(entity).State = EntityState.Deleted;
            return isSave ? _dbContext.SaveChanges() : 0;
        }

        public virtual int Delete(IEnumerable<TEntity> entities, bool isSave = true)
        {
            try
            {
                _dbContext.Configuration.AutoDetectChangesEnabled = false;
                return entities.Sum(entity => Delete(entity, isSave));
            }
            finally
            {
                _dbContext.Configuration.AutoDetectChangesEnabled = true;
            }
           
        }

        public virtual int Update(TEntity entity, bool isSave = true)
        {
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return isSave ? _dbContext.SaveChanges() : 0;
        }

        public IEnumerable<TEntity> Search()
        {
            return _dbContext.Set<TEntity>();
        }
    }
}
