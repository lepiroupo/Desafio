using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Desafio.Repository.Base
{
    public abstract class BaseRepository
    {
        private readonly IConfiguration _configuration;

        protected BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected T ObterObjeto<T>(string sql, object parametros, Func<dynamic, T> construtor) where T : class
        {
            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
            return sqlConnection.Query(sql, parametros).Select(construtor).FirstOrDefault();

        }
    }
}
