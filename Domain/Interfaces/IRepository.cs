using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public partial interface IRepository<TEntity> where TEntity :BaseEntity
    {
        /// <summary>
        /// Get Entity By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity</returns>
        Task<TEntity?> GetByIdAsync(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity?> GetDeletedByIdAsync(string id);
        /// <summary>
        /// Insert Entity In DataBase
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Insert(TEntity entity); 
        /// <summary>
        /// Update Entity In DataBase
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Update(TEntity entity);
        /// <summary>
        /// Delete Entity In DataBase
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Delete(TEntity entity);
        /// <summary>
        /// Save CURD
        /// </summary>
        /// <returns></returns>
        Task Save();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<int> GetCount();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<int> GetTrashCount();
    }
}
