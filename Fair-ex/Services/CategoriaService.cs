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
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            connection.Open();
            var categorias = await connection.QueryAsync<Categoria>("select * from categoria");
            return categorias.ToList();
        }

        public async Task<Categoria> GetCategoria(string id)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            var categoria = await connection.QueryFirstAsync<Categoria>("select * from categoria where idcategoria= @Id",
                new { Id = id });
            return categoria;
        }

        public async void CreateCategoria(Categoria c)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            var result = GetCategoria(c.Nome);
            if (result==null){
                await connection.ExecuteAsync("insert into categoria (idcategoria, tema_tema)" +
                    " values(@idcategoria, @tema)",
                    new { idcategoria = c.Nome, tema = c.Tema }); }
        }

        public async void UpdateCategoria(Categoria c)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("update categoria set idcategoria= @idcategoria, tema= @tema",
                new { idcategoria = c.Nome, tema = c.Tema });
        }

        public async void DeleteCategoria(string id)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("delete from categoria where idcategoria= @Id",
                new { Id = id });
        }
    }
}
