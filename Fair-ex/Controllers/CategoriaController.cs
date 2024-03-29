﻿using Dapper;
using Fair_ex.Models;
using Fair_ex.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Fair_ex.Controllers
{
    [Route("categoria/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private CategoriaService service;
        public CategoriaController( )
        {
            service = new CategoriaService();
        }
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetAllCategorias()
        {
            return Ok(service.GetAllCategorias());
        }
        [HttpGet("{idcategoria}")]
        public async Task<ActionResult<Categoria>> GetCategoria(string id)
        {
            return Ok(service.GetCategoria(id));
        }
        [HttpPost]
        public async void CreateCategoria(Categoria c)
        {
            service.CreateCategoria(c);
        }
        [HttpPut]
        public async void UpdateCategoria(Categoria c)
        {
            service.UpdateCategoria(c);
        }
        [HttpDelete("{idcategoria}")]
        public async void DeleteCategoria(string id)
        {
            service.DeleteCategoria(id);
        }

    }
}
