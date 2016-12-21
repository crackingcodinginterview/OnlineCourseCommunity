using OnlineCourseCommunity.Library.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseCommunity.Library.Service.Interface
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetById();
        Task<TEntity> CreateAsync();
        Task<TEntity> UpdateAsync();
        Task<bool> DeleteAsync();
    }
}
