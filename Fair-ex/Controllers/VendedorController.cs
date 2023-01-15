using Dapper;
using Fair_ex.Models;
using Fair_ex.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Fair_ex.Controllers
{
    [Route("vendedor/[controller]")]
    [ApiController]
    public class VendedorController : Controller
    {
        private VendedorService service;
        public VendedorController(IConfiguration config)
        {
            service = new VendedorService(config);
        }
        [HttpGet]
        public async Task<ActionResult<List<Vendedor>>> GetAllVendedores()
        {
            return Ok(service.GetAllVendedores());
        }
        [HttpGet("{username}")]
        public async Task<ActionResult<Vendedor>> GetVendedor(int username)
        {
            return Ok(service.GetVendedor(username));
        }
        [HttpPost]
        public async void CreateVendedor(Vendedor v)
        {
            service.CreateVendedor(v);
        }
        [HttpPut]
        public async void UpdateVendedor(Vendedor v)
        {
            service.UpdateVendedor(v);
        }
        [HttpDelete("{username}")]
        public async void DeleteVendedor(int username)
        {
            service.DeleteVendedor(username);
        }

    }
}
