﻿using Dapper;
using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Fair_ex.Controllers
{
    [Route("vendedor/[controller]")]
    [ApiController]
    public class VendedorController : Controller
    {
        private readonly IConfiguration _config;
        public VendedorController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public async Task<ActionResult<List<Vendedor>>> GetAllVendedores()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var vendedores = await connection.QueryAsync<Produto>("select * from Vendedor");
            return Ok(vendedores);
        }
        [HttpGet("{username}")]
        public async Task<ActionResult<Vendedor>> GetVendedor(int username)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var produto = await connection.QueryFirstAsync<Produto>("select * from Vendedor where username = @Id",
                new { Id = username });
            return Ok(produto);
        }
        [HttpPost]
        public async void CreateVendedor(Vendedor v)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into Vendedor (username, password, morada,telemovel,IBAN, avaliacao, receitaTotal, email)" +
                " values(@Username, @Password, @Morada, @Telemovel, @IBAN, @Avaliacao, @ReceitaTotal, @Email)",
                new { Username = v.Nome, Password = v.Password, Morada = v.Morada, Telemovel = v.Telemovel, IBAN = v.IBAN, Avaliacao = v.Avaliacao, ReceitaTotal = v.Email});
        }
        [HttpPut]
        public async void UpdateVendedor(Vendedor v)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update Vendedor set username= @Username, password = @Password, morada= @Morada, telemovel= @Telemovel,IBAN= @IBAN, avaliacao=@Avaliacao, receitaTotal= @ReceitaTotal, email= @Email",
                new { Username = v.Nome, Password = v.Password, Morada = v.Morada, Telemovel = v.Telemovel, IBAN = v.IBAN, Avaliacao = v.Avaliacao, ReceitaTotal = v.Email });
        }
        [HttpDelete("{username}")]
        public async void DeleteVendedor(int username)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from Vendedor where username = @Id",
                new { Id = username });
        }

    }
}
