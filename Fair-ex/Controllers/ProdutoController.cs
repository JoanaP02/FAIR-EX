using Dapper;
using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Fair_ex.Services;

namespace Fair_ex.Controllers
{
    [Route("produto/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private ProdutoService service;
        public ProdutoController(IConfiguration config)
        {
            service = new ProdutoService(config);
        }
        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetAllProdutos() {
            return Ok(service.GetAllProdutos());
        }
        [HttpGet("{idProduto}")]
        public async Task<ActionResult<Produto>> GetProduto(int idProduto)
        {
            return Ok(service.GetProduto(idProduto));
        }
        [HttpPost]
        public async void CreateProduto(Produto p)
        {
            service.CreateProduto(p);
        }
        [HttpPut]
        public async void UpdateProduto(Produto p)
        {
            service.UpdateProduto(p);
        }
        [HttpDelete("{idProduto}")]
        public async void DeleteProduto(int idProduto)
        {
            service.DeleteProduto(idProduto);
        }

    }
}
