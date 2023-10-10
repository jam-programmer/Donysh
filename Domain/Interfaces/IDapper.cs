using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public partial interface IDapper<TEntity> where TEntity : BaseEntity
    {  /// <summary>
       /// Get List With Pagination And Search
       /// </summary>
       /// <param name="isDelete"></param>
       /// <param name="storedProcedure"></param>
       /// <param name="search"></param>
       /// <param name="page"></param>
       /// <param name="pageSize"></param>
       /// <returns>List Of Entity</returns>
        Task<List<TEntity>> GetListAsync(bool isDelete,string storedProcedure, int page, int pageSize, string search = "");

    }
}
