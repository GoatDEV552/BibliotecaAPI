using BibliotecaAPI.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace BibliotecaAPI.Repositories
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


        public async Task<IEnumerable<Livro>> ListarLivrosAlugados()
        {
            using (var conn = Connection)
            {
                var sql = "SELECT * FROM Livros liv " +
                            "JOIN Livros liv on liv.Id = liv.id " +
                            "WHERE vag.Ocupada = true";

                return await conn.QueryAsync<Livro>(sql);
            }
        }
        public async Task<int> Criar(Livro dados)
        {
            var sql = "INSERT INTO tb_livros (Titulo,Autor,Genero,AnoPublicacao ) " +
                "values (@Titulo,@Autor,@Genero, @AnoPublicacao)";

            using (var conn = Connection)
            {
                return await conn.ExecuteAsync(sql,
                   new
                   {
                       Titulo = dados.Titulo,
                       Autor = dados.Autor,
                       Genero = dados.Genero,
                       AnoPublicao = dados.AnoPublicacao
                   });
            }
        }
        public async Task<int> Atualizar(Livro dados)
    {
        var sql = "UPDATE tb_livros set Titulo = @Titulo, Autor = @Autor, Genero = @AnoPublicacao WHERE Id = @id";

            using (var conn = Connection)
            {
                return await conn.ExecuteAsync(sql, dados);
            }
        }

        public async Task<int> DeletarPorId(int id)
        {
            var sql = "DELETE FROM tb_livros WHERE Id = @Id";

            using (var conn = Connection)
            {
                return await conn.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
