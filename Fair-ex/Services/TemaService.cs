using Dapper;
using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace Fair_ex.Services
{
    public class TemaService
    {
        private readonly IConfiguration _config;
        public TemaService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<Tema>> GetAllTemas()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var temas = await connection.QueryAsync<Tema>("select * from tema");
            return temas.ToList();
        }
        public async Task<Tema> GetTema(string nome)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var tema = await connection.QueryFirstAsync<Tema>("select * from tema where nome= @Nome",
                new { Nome = nome });
            return tema;
        }
        public async void CreateTema(Tema t)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into tema (nome, descricao)" +
                " values(@Nome, @Descricao)",
                new { Nome = t.Nome, Descricao = t.Descricao });
        }
        public async void UpdateTema(Tema t)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update tema set nome= @Nome, descricao= @Descricao",
                new { Nome = t.Nome, Descricao = t.Descricao });
        }
        public async void DeleteTema(string nome)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from tema where nome= @Nome",
                new { Nome = nome });
        }

    }
}
