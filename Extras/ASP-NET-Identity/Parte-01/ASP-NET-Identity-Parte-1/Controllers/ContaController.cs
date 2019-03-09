﻿using ASP_NET_Identity_Parte_1.Models;
using ASP_NET_Identity_Parte_1.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Identity_Parte_1.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(ContaRegistrarViewModel modelo)
        {
            if(ModelState.IsValid)
            {
                /*
                 * O contexto (DbContext (EntityFramework)) para gerenciar o banco de dados. Passo o a classe do banco de dados, para ele manipular
                 * Passando a connectionstring
                 */
                var dbContext = new IdentityDbContext<UserAplication>("DefaultConnection");
                /*
                 * O UserStore(); gera a interface entre o identity e o entityframework. Neste caso, estou criando a interface para os modelos do Usuário
                 * 
                 */
                var userStore = new UserStore<UserAplication>(dbContext);
                /*
                 * Uso o userManager para desacoplar o identity do entityframework e gerenciar as persistencia do usuário
                 */
                var userManager = new UserManager<UserAplication>(userStore);
                /*
                 * Criando um objeto para armazenar os dados do usuario
                 */
                var novoUsuario = new UserAplication();

                novoUsuario.Email = modelo.Email;
                novoUsuario.UserName = modelo.UserName;
                novoUsuario.FullName = modelo.NomeCompleto;

                // a senha vai como argumento pois ela fica armazenada em outro lugar. Por padrão, o UserManager salva alterações automáticamente
                await userManager.CreateAsync(novoUsuario, modelo.Senha);
                // não preciso mais do dbContext, pois irei usar algo menos desacoplado
                //dbContext.Users.Add(novoUsuario);
                //dbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(modelo);
        }
    }
}

/*
 * Arquitetura do Identity
 * Fontes de Dados (SQL, MongoDB)
 * Acesso aos Dados (EntityFramework, NHibernate)
 * Fonecedor/Store (UserStore)
 * Gerenciador/Managers (UserManager)
 * Aplicação
 * 
 * 
 * A aplicação conversa apenas com o gerenciador para a manipulação dos dados do usuário
 */