using Domain.Entities;

namespace Domain.Interfaces
{
    public partial interface IDapper<TEntity> 
    {  /// <summary>
       /// Get List With Pagination And Search
       /// </summary>
       /// <param name="isDelete"></param>
       /// <param name="storedProcedure"></param>
       /// <param name="search"></param>
       /// <param name="page"></param>
       /// <param name="pageSize"></param>
       /// <returns>List Of Entity</returns>
        Task<List<TEntity>> GetListAsync(bool isDelete, string storedProcedure, int page, int pageSize, string search = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="tableResult"></param>
        /// <param name="entityId"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        Task InsertWithOutColumn(string table, string entityId, List<string> values);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="tableResult"></param>
        /// <param name="entityKey"></param>
        /// <param name="entityValue"></param>
        /// <returns></returns>
        Task<List<string>> GetRelations(string table, string tableResult, string entityKey,string entityValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="deleteKey"></param>
        /// <param name="deleteValue"></param>
        /// <returns></returns>
        Task DeleteAsync(string table,string deleteKey,string deleteValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <returns></returns>
        Task<List<TEntity>> Execute(string storedProcedure,object parmeter);

        Task<List<TEntity>> ExecuteQuery(string query);
        Task<TEntity> ExecuteSP(string sp);
    }
}
