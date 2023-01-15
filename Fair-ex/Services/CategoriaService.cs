using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;

namespace Fair_ex.Services
{
    public class CategoriaService
    {
        private readonly IConfiguration _config;
        public CategoriaService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<Categoria>> GetAllCategorias()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var categorias = await connection.QueryAsync<Categoria>("select * from categoria");
            return categorias.ToList();
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var categoria = await connection.QueryFirstAsync<Categoria>("select * from categoria where idcategoria= @Id",
                new { Id = id });
            return categoria;
        }

        public async void CreateCategoria(Categoria c)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var tema = c.Tema;
            var existingTema = await connection.QueryFirstOrDefaultAsync<Tema>("select * from tema where nome = @nome",
                new { nome = tema.Nome });
            if (existingTema == null)
            {
                await connection.ExecuteAsync("insert into tema (nome, descricao) values(@nome, @descricao)",
                    new { nome = tema.Nome, descricao = tema.Descricao });
            }
            await connection.ExecuteAsync("insert into categoria (idcategoria, tema_tema) values(@idcategoria, @tema_tema)",
                new { idcategoria = c.Nome, tema_tema = tema.Nome });
        }


        public async void UpdateCategoria(Categoria c)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update categoria set idcategoria= @idcategoria, tema= @tema",
                new { idcategoria = c.Nome, tema = c.Tema });
        }

        public async void DeleteCategoria(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from categoria where idcategoria= @Id",
                new { Id = id });
        }
    }
}
