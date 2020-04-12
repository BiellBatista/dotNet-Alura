﻿using _06_04_XX_CasaDoCodigo.Models;
using _06_04_XX_CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _06_04_XX_CasaDoCodigo.Areas.Catalogo.Data
{
    public class CatalogoDbContext : DbContext
    {
        // chamando o construtor pai (base) e passando o parametro
        public CatalogoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>(b =>
            {
                b.HasKey(t => t.Id);
            });

            modelBuilder.Entity<Produto>(b =>
            {
                b.HasKey(t => t.Id);
            });
        }

        private List<Livro> GetLivros()
        {
            var json = File.ReadAllText("data/livros.json");

            return JsonConvert.DeserializeObject<List<Livro>>(json);
        }

        private List<Produto> GetProdutos()
        {
            var livros = GetLivros();
            var categorias = livros
                .Select(l => l.Categoria) //projeção (transformação de dados)
                .Distinct()
                .Select((nomeCategoria, index) =>
                {
                    var categoria = new Categoria(nomeCategoria);
                    categoria.Id = index + 1;

                    return categoria;
                });

        }
    }
}
