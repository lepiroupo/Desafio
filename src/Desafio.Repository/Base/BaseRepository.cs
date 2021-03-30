using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Desafio.Repository.Base
{
    public abstract class BaseRepository
    {
        private readonly SqlConnection _connection;
        protected BaseRepository(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("SqlConnection"));
        }        
        protected int ExecutarConsultaSemRetorno(string sql, object parametros)
        {
            return _connection.Execute(sql, parametros);
        }
        protected T ObterObjeto<T>(string sql, object parametros, Func<dynamic, T> construtor) where T : class
        {
            return _connection.Query(sql, parametros).Select(construtor).FirstOrDefault();
        }
        protected IEnumerable<T> ObterLista<T>(string sql, Func<dynamic, T> construtor) where T : class
        {
            return _connection.Query(sql).Select(construtor);
        }
    }
}
