﻿using Dapper;
using Fair_ex.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace Fair_ex.Services
{
    public class FeiraService
    {
        private readonly IConfiguration _config;
        public FeiraService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<Feira>> GetAllFeiras()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var query = @"SELECT * FROM feira f 
                  JOIN tema t ON f.tema_tema = t.nome; ";
            var feiras = await connection.QueryAsync<Feira, Tema, Feira>(query, (f, t) => {
                f.Tema = t;
                return f;
            }).ConfigureAwait(false);
            return feiras.ToList();
        }

        public async Task<Feira> GetFeira(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var query = @"SELECT * FROM feira f 
                  JOIN tema t ON f.tema_tema = t.nome
                  WHERE f.idfeira = @id; ";
            var feira = await connection.QueryAsync<Feira, Tema, Feira>(query, (f, t) => {
                f.Tema = t;
                return f;
            }, new { id }).ConfigureAwait(false);
            return feira.FirstOrDefault();
        }


        public async void CreateFeira(Feira f)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into feira (idfeira,tema_tema,dataDeInicioInscricao,dataDeFimInscricao,dataComeco,dataTermino)" +
                " values(@Id, @Tema, @DII, @DFI, @DC, @DT)",
                new
                {
                    Id = f.Id,
                    Tema = f.Tema.Nome,
                    DII = f.DataIncricaoIninio,
                    DFI = f.DataIncricaoFim,
                    DC = f.DataComecoInicio,
                    DT = f.DataComecoFim
                });
        }
        public async void UpdateFeira(Feira f)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update feira set idfeira=@Id, tema_tema=@Tema, dataDeInicioInscricao=@DII," +
                "dataDeFimInscricao= @DFI,dataComeco= @DC, dataTermino=@DT)",
                new
                {
                    Id = f.Id,
                    Tema = f.Tema.Nome,
                    DII = f.DataIncricaoIninio,
                    DFI = f.DataIncricaoFim,
                    DC = f.DataComecoInicio,
                    DT = f.DataComecoFim
                });
        }
        public async void DeleteFeira(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from feira where idfeira = @Id",
                new { Id = id });
        }

    }
}
