using BibliotecaAPI.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace BibiliotecaApi.Repositories
{
    public class BibliotecaRepositorys
    {
        private readonly string _connectionString;

        public BibliotecaRepositorys(string connectionString)
        {
            _connectionString = connectionString;
        }
        private IDbConnection Connection =>
            new MySqlConnection(_connectionString);


        public async Task<int> Criar(Usuario dados)
        {
            var sql = "INSERT INTO tb_usuario (Nome, Email) " +
                "values (@Nome,@Email)";

            using (var conn = Connection)
            {
                return await conn.ExecuteAsync(sql,
                   new
                   {
                       Nome = dados.Nome,
                       Email = dados.Email,
                   });
            }
        }
    }
}

