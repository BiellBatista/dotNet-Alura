﻿using Alura.ListaLeitura.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Alura.WebAPI.WebApp.HttpClients;

namespace Alura.ListaLeitura.WebApp.Controllers
{
    [Authorize]
    public class LivroController : Controller
    {
        //private readonly IRepository<Livro> _repo;
        private readonly LivroApiClient _api;

        //public LivroController(IRepository<Livro> repository, LivroApiClient api)
        public LivroController(LivroApiClient api)
        {
            //não preciso mais do repository, pois estou consumindo minha API
            //_repo = repository;
            _api = api;
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View(new LivroUpload());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo(LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                await _api.PostLivroAsync(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ImagemCapa(int id)
        {
            byte[] img = await _api.GetCapaLivroAsync(id);

            if (img != null)
            {
                return File(img, "image/png");
            }
            return File("~/images/capas/capa-vazia.png", "image/png");
        }

        public async Task<LivroApi> RecuperaLivro(int id)
        {
            return await _api.GetLivroAsync(id);
            //return _repo.Find(id);
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int id)
        {
            var model = await _api.GetLivroAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model.ToUpload());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detalhes(LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                //var livro = model.ToLivro();
                //if (model.Capa == null)
                //{
                //    livro.ImagemCapa = _repo.All
                //        .Where(l => l.Id == livro.Id)
                //        .Select(l => l.ImagemCapa)
                //        .FirstOrDefault();
                //}
                //_repo.Alterar(livro);
                await _api.PutLivroAsync(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remover(int id)
        {
            var model = await _api.GetLivroAsync(id);

            if (model == null)
            {
                return NotFound();
            }
            await _api.DeleteLivroAsync(id);
            return RedirectToAction("Index", "Home");
        }
    }
}