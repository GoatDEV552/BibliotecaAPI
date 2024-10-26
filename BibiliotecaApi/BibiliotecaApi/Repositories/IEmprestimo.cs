using BibliotecaAPI.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace BibiliotecaApi.Repositories
{
    public class BibliotecaRepository
    {
        private readonly string _connectionString;

        public BibliotecaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        private IDbConnection Connection =>
            new MySqlConnection(_connectionString);


        public async Task<int> RegistrarEmprestimo(Emprestimo dados)
        {
            var sql = "INSERT INTO tb_emprestimos (DataEmprestimo, DataDevolucao) " +
                "values (@DataEmprestimo,@DataDevolucao)";

            using (var conn = Connection)
            {
                return await conn.ExecuteAsync(sql,
                   new
                   {
                       DataEmprestimo = dados.DataEmprestimo,
                       DataDevolucao = dados.DataDevolucao,
                   });
            }
        }
        public async Task<Emprestimo> BuscarPorId(int id)
        {
            var sql = "SELECT * FROM tb_emprestimos WHERE Id = @Id";

            using (var conn = Connection)
            {
                return await conn.QueryFirstOrDefaultAsync<Emprestimo>(sql, new { Id = id });
            }
        }
    }
}

