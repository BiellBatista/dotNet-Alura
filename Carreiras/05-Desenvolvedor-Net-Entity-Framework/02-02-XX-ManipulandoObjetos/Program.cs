﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            //RecuperarProdutos();
            //ExcluirProdutos();
            //RecuperarProdutos();
            AtualizarProduto();
        }

        private static void AtualizarProduto()
        {
            // incluir um produto
            GravarUsandoEntity();
            RecuperarProdutos();

            // atualizar o produto
            using(var repo = new ProdutoDAO())
            {
                // pegando o dado para o que o mesmo possa ser atualizado
                Produto primeiro = repo.Produtos().First();
                primeiro.Nome = "Cassino Royale";
                //repo.Produtos.Update(primeiro);
                //repo.SaveChanges();
                repo.Atualizar(primeiro);
            }

            // codigo antigo logo abaixo
            /**
             * using(var repo = new LojaContext())
            {
                // pegando o dado para o que o mesmo possa ser atualizado
                Produto primeiro = repo.Produtos.First();
                primeiro.Nome = "Cassino Royale";
                repo.Produtos.Update(primeiro);
                repo.SaveChanges(); //não preciso mais salvar, porque isso será no ProdutoDAOEntity
            }

            RecuperarProdutos();
             */

            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos().ToList();
                foreach (var item in produtos)
                {
                    repo.Remover(item);
                }
            }

            /**
             * 
             * using (var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList();

                foreach (var item in produtos)
                {
                    repo.Produtos.Remove(item);
                }
                repo.SaveChanges();
            }
             */
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                // indo até o banco para realizar um select * e gerar uma lista
                IList<Produto> produtos = repo.Produtos();
                Console.WriteLine("Foram encontrados {0} produto(s).", produtos.Count);
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }

            /*
             * using (var repo = new LojaContext())
            {
                // indo até o banco para realizar um select * e gerar uma lista
                IList<Produto> produtos = repo.Produtos.ToList();
                Console.WriteLine("Foram encontrados {0} produto(s).", produtos.Count);
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
             */
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;
            // por conversao, devo utilizar a palavra "context" para declarar um contexto.
            // neste caso, estou usando um contexto de loja que terá produto, vendedores...
            using (var contexto = new ProdutoDAOEntity())
            {
                contexto.Adicionar(p);
            }

            /**
             * using (var contexto = new LojaContext())
            {
                contexto.Produtos.Add(p);
                contexto.SaveChanges();
            }
             */
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
