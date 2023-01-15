using Dapper;
using Fair_ex.Models;
using Fair_ex.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Fair_ex.Controllers
{
    [Route("stand/[controller]")]
    [ApiController]
    public class StandController : Controller
    {
        private StandService service;
        public StandController( )
        {
            service = new StandService();
        }
        [HttpGet]
        public async Task<ActionResult<List<Stand>>> GetAllStands()
        {
            return Ok(service.GetAllStands());
        }
        [HttpGet("{feira_idfeira}/{Vendedor_username}")]
        public async Task<ActionResult<Stand>> GetStand(int idFeira, string NomeVendedor)
        {
            return Ok(service.GetStand(idFeira,NomeVendedor));
        }
        [HttpPost]
        public async void CreateStand(Stand s, int idFeira)
        {
            service.CreateStand(s, idFeira);
        }
        [HttpPut]
        public async void UpdateStand(Stand s, int idFeira)
        {
            service.UpdateStand(s, idFeira);
        }
        [HttpDelete("{feira_idfeira}/{Vendedor_username}")]
        public async void DeleteStand(int idFeira, string NomeVendedor)
        {
            service.DeleteStand(idFeira, NomeVendedor);
        }

    }
}
