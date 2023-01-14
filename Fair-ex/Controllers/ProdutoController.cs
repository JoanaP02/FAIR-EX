using Dapper;
using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Fair_ex.Controllers
{
    [Route("produto/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IConfiguration _config;
        public ProdutoController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetAllProdutos() {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var produtos = await connection.QueryAsync<Produto>("select * from Produtos");
            return Ok(produtos);
        }
        [HttpGet("{idProduto}")]
        public async Task<ActionResult<Produto>> GetProduto(int idProduto)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var produto = await connection.QueryFirstAsync<Produto>("select * from Produtos where idProduto = @Id",
                new {Id = idProduto});
            return Ok(produto);
        }
        [HttpPost]
        public async void CreateProduto(Produto p)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into Produtos (idProduto, Nome, categoria_idcategoria,Descricao,Preco, Stand_feira_idfeira, Stand_Vendedor_username)" +
                " values(@Id, @Nome, @Categoria, @Descricao, @Preco, @Idfeira, @Username)",
                new { Id = p.Id, Nome = p.Nome, Categoria = p.Categoria, Descricao = p.Descricao, Preco = p.Preco, IdFeira = p.IdFeira, Username = p.UsernameVendedor });
        }
        [HttpPut]
        public async void UpdateProduto(Produto p)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update Produtos set idProduto= @Id, Nome= @Nome, categoria_idcategoria=@Categoria,Descricao=@Descricao,Preco=@Preco, Stand_feira_idfeira= @IdFeira, Stand_Vendedor_username= @Username",
                new { Id = p.Id, Nome = p.Nome, Categoria = p.Categoria, Descricao = p.Descricao, Preco = p.Preco, IdFeira = p.IdFeira, Username = p.UsernameVendedor });
        }
        [HttpDelete("{idProduto}")]
        public async void DeleteProduto(int idProduto)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from Produtos where idProduto = @Id",
                new { Id = idProduto });
        }

    }
}
