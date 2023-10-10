using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure.Repositories
{
    public class DapperRepository<TEntity> : IDapper<TEntity> where TEntity : BaseEntity
    {
        private readonly SqlConnection _connection;
        public DapperRepository()
        {
            _connection = new SqlConnection(ConnectionOptions.ConnectionString);
        }

        public async Task<List<TEntity>> GetListAsync(bool isDelete, string storedProcedure, int page, int pageSize, string search = "")
        {
            IEnumerable<TEntity> entities;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@page", page, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@pageSize", pageSize, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@search", search, DbType.String, ParameterDirection.Input);
            parameters.Add("@delete", isDelete, DbType.Boolean, ParameterDirection.Input);
            try
            {
                _connection.Open();
           
                entities = await _connection.QueryAsync<TEntity>($"{storedProcedure}", parameters,commandType:CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                _connection.Dispose();
                _connection.Close();

            }

            return entities.ToList();
        }
    }
}
