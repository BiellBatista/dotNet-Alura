﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_07_XX_Agrupamento_Agregacao.Antes
{
    public class AgrupamentoAgregacao : IAulaItem
    {
        public void Executar()
        {
            var filmes = GetFilmes();
            var diretores = GetDiretores();

            var novoFilme = new Filme4
            {
                Titulo = "A Fantástica Fábrica de Chocolate",
                Ano = 2005,
                Diretor = new Diretor4 { Id = 3, Nome = "Tim Burton" },
                DiretorId = 3,
                Minutos = 115
            };

            filmes.Add(novoFilme);

            Console.WriteLine("\nTodos os filmes");
            Console.WriteLine("===============");

            Imprimir(filmes);

            Console.WriteLine("\nFiltrando por nome de diretor");
            Console.WriteLine("=============================");
            var consulta =
                from f in filmes
                where f.Diretor.Nome == "Tim Burton"
                select f;

            Imprimir(consulta);

            Console.WriteLine("\nFiltrando e projetando resultado");
            Console.WriteLine("================================");
            var consulta2 =
                from f in filmes
                where f.Diretor.Nome == "Tim Burton"
                select new FilmeResumido3
                {
                    Titulo = f.Titulo,
                    Diretor = f.Diretor.Nome
                };

            Console.WriteLine("\nRelacionando duas sequências");
            Console.WriteLine("============================");

            var consulta4 =
                from f in filmes
                join d in diretores
                    on f.DiretorId equals d.Id
                where f.Diretor.Nome == "Tim Burton"
                select new //OBJETO ANÔNIMO
                {
                    f.Titulo,
                    Diretor = d.Nome
                };

            Console.WriteLine($"{"Título",-40} {"Diretor",-20}");
            Console.WriteLine(new string('=', 64));

            foreach (var filme in consulta4)
            {
                Console.WriteLine($"{filme.Titulo,-40} {filme.Diretor,-20}");
            }

            Console.WriteLine();
            Console.WriteLine("\nAgrupando consulta");
            Console.WriteLine("==================");

            var consulta5 =
                from f in filmes
                join d in diretores
                    on f.DiretorId equals d.Id
                group f by d
                    into agrupado
                select new //OBJETO ANÔNIMO
                {
                    Diretor = agrupado.Key,
                    Quantidade = agrupado.Count(),
                    Total = agrupado.Sum(f => f.Minutos),
                    Min = agrupado.Min(f => f.Minutos),
                    Max = agrupado.Max(f => f.Minutos),
                    Media = (int)agrupado.Average(f => f.Minutos)
                };

            Console.WriteLine(
                $"{"Nome",-30}" +
                $"\t{"Qtd"}" +
                $"\t{"Total"}" +
                $"\t{"Min"}" +
                $"\t{"Max"}" +
                $"\t{"Media"}");
            foreach (var item in consulta5)
            {
                Console.WriteLine(
                    $"{item.Diretor.Nome,-30}" +
                    $"\t{item.Quantidade}" +
                    $"\t{item.Total}" +
                    $"\t{item.Min}" +
                    $"\t{item.Max}" +
                    $"\t{item.Media}");
            }

            Console.ReadKey();
        }

        private void Imprimir(IEnumerable<Filme4> filmes)
        {
            Console.WriteLine($"{"Título",-40} {"Diretor",-20} {"Ano",4}");
            Console.WriteLine(new string('=', 64));
            foreach (var filme in filmes)
            {
                Console.WriteLine($"{filme.Titulo,-40} {filme.Diretor.Nome,-20} {filme.Ano,4}");
            }
        }

        private void Imprimir(IEnumerable<FilmeResumido3> filmes)
        {
            Console.WriteLine($"{"Título",-40} {"Diretor",-20}");
            Console.WriteLine(new string('=', 64));
            foreach (var filme in filmes)
            {
                Console.WriteLine($"{filme.Titulo,-40} {filme.Diretor,-20}");
            }
            Console.WriteLine();
        }

        private List<Diretor4> GetDiretores()
        {
            return new List<Diretor4>
            {
                new Diretor4 { Id = 1, Nome = "Quentin Tarantino" },
                new Diretor4 { Id = 2, Nome = "James Cameron" },
                new Diretor4 { Id = 3, Nome = "Tim Burton" }
            };
        }

        private List<Filme4> GetFilmes()
        {
            return new List<Filme4> {
                new Filme4 {
                    DiretorId = 1,
                    Diretor = new Diretor4 { Nome = "Quentin Tarantino" },
                    Titulo = "Pulp Fiction",
                    Ano = 1994,
                    Minutos = 2 * 60 + 34
                },
                new Filme4 {
                    DiretorId = 1,
                    Diretor = new Diretor4 { Nome = "Quentin Tarantino" },
                    Titulo = "Django Livre",
                    Ano = 2012,
                    Minutos = 2 * 60 + 45
                },
                new Filme4 {
                    DiretorId = 1,
                    Diretor = new Diretor4 { Nome = "Quentin Tarantino" },
                    Titulo = "Kill Bill Volume 1",
                    Ano = 2003,
                    Minutos = 1 * 60 + 51
                },

                new Filme4 {
                    DiretorId = 2,
                    Diretor = new Diretor4 { Nome = "James Cameron" },
                    Titulo = "Avatar",
                    Ano = 2009,
                    Minutos = 2 * 60 + 42
                },
                new Filme4 {
                    DiretorId = 2,
                    Diretor = new Diretor4 { Nome = "James Cameron" },
                    Titulo = "Titanic",
                    Ano = 1997,
                    Minutos = 3 * 60 + 14
                },
                new Filme4 {
                    DiretorId = 2,
                    Diretor = new Diretor4 { Nome = "James Cameron" },
                    Titulo = "O Exterminador do Futuro",
                    Ano = 1984,
                    Minutos = 1 * 60 + 47
                },

                new Filme4 {
                    DiretorId = 3,
                    Diretor = new Diretor4 { Nome = "Tim Burton" },
                    Titulo = "O Estranho Mundo de Jack",
                    Ano = 1993,
                    Minutos = 1 * 60 + 16
                },
                new Filme4 {
                    DiretorId = 3,
                    Diretor = new Diretor4 { Nome = "Tim Burton" },
                    Titulo = "Alice no País das Maravilhas",
                    Ano = 2010,
                    Minutos = 1 * 60 + 48
                },
                new Filme4 {
                    DiretorId = 3,
                    Diretor = new Diretor4 { Nome = "Tim Burton" },
                    Titulo = "A Noiva Cadáver",
                    Ano = 2005,
                    Minutos = 1 * 60 + 17
                }
            };
        }
    }

    public class Diretor4
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class Filme4
    {
        public int DiretorId { get; set; }
        public Diretor4 Diretor { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public int Minutos { get; set; }
    }

    public class FilmeResumido3
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }
    }
}
