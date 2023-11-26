using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Repositories
{
    public class DapperRepository<TEntity> : IDapper<TEntity> 
    {
        private readonly SqlConnection _connection;
        public DapperRepository()
        {
            _connection = new SqlConnection(ConnectionOptions.ConnectionString);
        }

        public async Task DeleteAsync(string table, string deleteKey, string deleteValue)
        {
            string query = $"DELETE FROM {table} WHERE {deleteKey} = '{deleteValue}' ;";
            try
            {
                _connection.Open();
                await _connection.ExecuteAsync(query);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _connection.Dispose();
                _connection.Close();
            }
        }

        public async Task<List<TEntity>> Execute(string storedProcedure, object parmeter)
        {
            if (string.IsNullOrEmpty(storedProcedure))
            {

            }
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Home", parmeter, DbType.Boolean, ParameterDirection.Input);
                await  _connection.OpenAsync();
              var model =await _connection.QueryAsync<TEntity>(storedProcedure, parameters ,commandType: CommandType.StoredProcedure);
              return model.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<TEntity>> ExecuteQuery(string query)
        {

            if (string.IsNullOrEmpty(query))
            {

            }
            try
            {

                await _connection.OpenAsync();
                var model = await _connection.QueryAsync<TEntity>(query, commandType: CommandType.Text);
                return model.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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

        public async Task<List<string>> GetRelations(string table, string tableResult, string entityKey, string entityValue)
        {
            List<string> result;
            string query = $"SELECT {tableResult} FROM {table} WHERE {entityKey} = '{entityValue}' ";
            try
            {
                _connection.Open();
                var response = await _connection.QueryAsync<string>(query);
                result = response.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _connection.Dispose();
                _connection.Close();
            }

            return result;
        }

        public async Task InsertWithOutColumn(string table, string entityId, List<string> values)
        {
            string[] valueTable = values.ToArray();
            string query= $" INSERT INTO {table} VALUES ";
            for (int i = 0; i < values.Count; i++)
            {
                if (i + 1 == values.Count)
                {
                    query += $" ( '{entityId}','{valueTable.ElementAt(i)}' ) ;";
                }
                else
                {
                    query += $" ( '{entityId}','{valueTable.ElementAt(i)}' ) ,";
                }
            }

            try
            {
                await using var localConnection= new SqlConnection(ConnectionOptions.ConnectionString);
                localConnection.Open();
                await localConnection.ExecuteAsync(query);

                //_connection.Open();
                //await _connection.ExecuteAsync(query);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _connection.Dispose();
                _connection.Close();
            }
        }
    }
}
