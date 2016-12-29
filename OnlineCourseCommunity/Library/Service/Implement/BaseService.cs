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
            this._dbSet = this._context.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                this._dbSet.Add(entity);
                await this._context.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                if (this._context.Entry(entity).State == EntityState.Detached)
                    this._dbSet.Attach(entity);
                this._dbSet.Remove(entity);
                await this._context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await this._dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await this._dbSet.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                this._context.Entry(entity).State = EntityState.Modified;
                if (this._context.Entry(entity).State == EntityState.Detached)
                    this._dbSet.Attach(entity);
                await this._context.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}