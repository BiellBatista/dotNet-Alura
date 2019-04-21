﻿using Alura.ListaLeitura.App.Logica;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        // Os parametros IXXXX serve para passar a responsabilidade de criação para o ASP.NET Core. Injeção de depedência
        public void ConfigureServices(IServiceCollection services)
        {
            // falando que a aplicação usa o serviço de roteamento nativo do ASP.NET Core
            services.AddRouting(); //injentando serviço de roteamento
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app); //criando o objeto complexo de rotas
            //configurando as rotas (Mapeando as rotas)
            builder.MapRoute("Livros/ParaLer", LivrosLogica.LivrosParaLer); //para cada rota que quero atender, chamo o método MapRoute()
            builder.MapRoute("Livros/Lendo", LivrosLogica.LivrosLendo); //para cada rota que quero atender, chamo o método MapRoute()
            builder.MapRoute("Livros/Lidos", LivrosLogica.LivrosLidos); //para cada rota que quero atender, chamo o método MapRoute()
            builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.NovoLivroParaLer); //criando uma rota com template.
            builder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.ExibeDetalhes); //criando uma rota com template que aceite apenas int como parametro. Assim, o servido não atenden esta chamada e evita erros 500, pois não haverá erro na hora de converter uma string para um inteiro
            // Rota com template segue o padrão Cadastro/NovoLivro/{nome}/{autor}, onde os valores entre {} são argumentos
            builder.MapRoute("Cadastro/NovoLivro", CadastroLogica.ExibeFormulario);
            builder.MapRoute("Cadastro/Incluir", CadastroLogica.ProcessaFormulario);

            var rotas = builder.Build(); //construindo as rotas. O método Build() é usado para construir objetos complexos
            app.UseRouter(rotas); //usando a rota nativa do Core e deixando a minha rota de lado

            /*
             * A sequência de requisição e resposta é chamada de, no .CORE, RequestPipeline
             * A interface IApplicationBuilder é responsável por fazer o pipeline
             */
            //app.Run(LivrosParaLer); //execute o método LivrosParaLer. Um RequestDelegate é um método que tem como retorno um Task
            //app.Run(Roteamento); //minha rota
        }

        // qualquer requisição realizada no browser, irá passar pelo roteador
        // o context serve para ver tudo que posso fazer no contexto do HTTP
        // não estou mais usando este método, pois o roteamento utilizado é o padrão do Core
        //public Task Roteamento(HttpContext context)
        //{
        //    var _repo = new LivroRepositorioCSV();
        //    //var caminhosAtendidos = new Dictionary<string, string>
        //    //{
        //    //    {"/Livros/ParaLer", _repo.ParaLer.ToString() },
        //    //    {"/Livros/Lendo", _repo.Lendo.ToString() },
        //    //    {"/Livros/Lidos", _repo.Lidos.ToString() }
        //    //};

        //    var caminhosAtendidos = new Dictionary<string, RequestDelegate>
        //    {
        //        {"/Livros/ParaLer", LivrosParaLer },
        //        {"/Livros/Lendo", LivrosLendo },
        //        {"/Livros/Lidos", LivrosLidos }
        //    };

        //    if (caminhosAtendidos.ContainsKey(context.Request.Path))
        //    {
        //        var metodo = caminhosAtendidos[context.Request.Path];
        //        return metodo.Invoke(context); //invocando um método delegate e passando o contexto (ambiente do usuário) para ele saber onde irá a resposta
        //        //return context.Response.WriteAsync(caminhosAtendidos[context.Request.Path]);
        //    }
        //    context.Response.StatusCode = 404; // adicionado um código de erro (404) para página não encontrada. Posso colocar qualquer coisa
        //    return context.Response.WriteAsync("Caminho não encontrado");
        //}
    }
}
