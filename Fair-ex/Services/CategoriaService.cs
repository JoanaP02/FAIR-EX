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
            var temas = await connection.QueryAsync<Tema>("select * from tema");
            foreach (var c in categorias)
            {
                var tema = temas.FirstOrDefault(t => t.Nome == c.Tema.Nome);
                if (tema != null)
                    c.Tema = tema;
            }
            return categorias.ToList();
        }

        public async Task<Categoria> GetCategoria(string id)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            var categoria = await connection.QueryFirstAsync<Categoria>("select * from categoria where idcategoria= @Id",

                new { Id = id });
            if (categoria.Tema != null)
            {
                var tema = await connection.QueryFirstAsync<Tema>("select * from tema where nome = @nome",
                new { nome = categoria.Tema.Nome });
                categoria.Tema = tema;
            }
            return categoria;
        }



        public async void CreateCategoria(Categoria c)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
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
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
          
            var tema = c.Tema;
            await connection.ExecuteAsync("update tema set nome= @nome, descricao= @descricao where nome= @tema_nome",
                new { nome = tema.Nome, descricao = tema.Descricao, tema_nome = tema.Nome });
            await connection.ExecuteAsync("update categoria set idcategoria= @idcategoria, tema_tema= @tema_tema where idcategoria= @id",
                new { idcategoria = c.Nome, tema_tema = tema.Nome, id = c.Nome });
        }



        public async void DeleteCategoria(string id)
        {
            using var connection = new SqlConnection("Server=localhost;Database=FairEX;User Id=sa;Password=Password1234;");
            await connection.ExecuteAsync("delete from categoria where idcategoria= @Id",
                new { Id = id });
        }

    }
}
