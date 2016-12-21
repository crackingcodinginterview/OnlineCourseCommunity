using OnlineCourseCommunity.Library.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using OnlineCourseCommunity.Library.Core.Domain;
using System.Data.Entity;

namespace OnlineCourseCommunity.Library.Service.Implement
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected DbContext _context;
        protected DbSet<TEntity> _dbSet;
        public BaseService(DbContext context)
        {
            this._context = context;
        }
        public Task<TEntity> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}