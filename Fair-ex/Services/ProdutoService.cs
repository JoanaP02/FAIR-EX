using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;

namespace Fair_ex.Services
{
    public class ProdutoService
    {
        private readonly IConfiguration _config;
        public ProdutoService(IConfiguration config)
        {
            _config = config;
        }
        
        public async Task<List<Produto>> GetAllProdutos()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var produtos = await connection.QueryAsync<Produto>("select * from Produtos");
            return produtos.ToList();
        }
        
        public async Task<Produto> GetProduto(int idProduto)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var produto = await connection.QueryFirstAsync<Produto>("select * from Produtos where idProduto = @Id",
                new { Id = idProduto });
            return produto;
        }
        
        public async void CreateProduto(Produto p)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            Categoria c = p.Categoria;
            await connection.ExecuteAsync("insert into categoria (idcategoria, tema)" +
                " values(@idcategoria, @tema)",
                new { idcategoria = c.Nome, tema = c.Tema });
            await connection.ExecuteAsync("insert into Produtos (idProduto, Nome, categoria_idcategoria,Descricao,Preco, Stand_feira_idfeira, Stand_Vendedor_username)" +
                " values(@Id, @Nome, @Categoria, @Descricao, @Preco, @Idfeira, @Username)",
                new { Id = p.Id, Nome = p.Nome, Categoria = p.Categoria.Nome, Descricao = p.Descricao, Preco = p.Preco, IdFeira = p.IdFeira, Username = p.UsernameVendedor });
        }
        
        public async void UpdateProduto(Produto p)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            Categoria c = p.Categoria;
            await connection.ExecuteAsync("update categoria set idcategoria= @idcategoria, tema= @tema",
                new { idcategoria = c.Nome, tema = c.Tema });
            await connection.ExecuteAsync("update Produtos set idProduto= @Id, Nome= @Nome, categoria_idcategoria=@Categoria,Descricao=@Descricao,Preco=@Preco, Stand_feira_idfeira= @IdFeira, Stand_Vendedor_username= @Username",
                new { Id = p.Id, Nome = p.Nome, Categoria = p.Categoria.Nome, Descricao = p.Descricao, Preco = p.Preco, IdFeira = p.IdFeira, Username = p.UsernameVendedor });
        }
        
        public async void DeleteProduto(int idProduto)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from Produtos where idProduto = @Id",
                new { Id = idProduto });
        }
    }
}
