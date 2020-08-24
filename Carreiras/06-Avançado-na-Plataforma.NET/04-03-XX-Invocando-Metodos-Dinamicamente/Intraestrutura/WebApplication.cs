﻿using _04_03_XX_Invocando_Metodos_Dinamicamente.Controller;
using System;
using System.Net;
using System.Reflection;
using System.Text;

namespace _04_03_XX_Invocando_Metodos_Dinamicamente.Intraestrutura
{
    public class WebApplication
    {
        private readonly string[] _prefixos;

        public WebApplication(string[] prefixos)
        {
            if (prefixos == null)
            {
                throw new ArgumentNullException(nameof(prefixos));
            }

            _prefixos = prefixos;
        }

        public void Iniciar()
        {
            while (true)
            {
                ManipularRequisicao();
            }
        }

        private void ManipularRequisicao()
        {
            var httpListener = new HttpListener();

            foreach (var prefixo in _prefixos)
            {
                httpListener.Prefixes.Add(prefixo);
            }

            httpListener.Start();

            var contexto = httpListener.GetContext();
            var requisicao = contexto.Request;
            var response = contexto.Response;

            var path = requisicao.Url.AbsolutePath;

            if (Utilidades.EhArquivo(path))
            {
                var manipulador = new ManipuladorRequisicaoArquivo();
                manipulador.Manipular(response, path);
            }
            else if (path == "/Cambio/MXN")
            {
                var controller = new CambioController();
                var paginaConteudo = controller.MXN();
                var bufferArquivo = Encoding.UTF8.GetBytes(paginaConteudo);

                response.OutputStream.Write(bufferArquivo, 0, bufferArquivo.Length);
                response.ContentType = "text/html; charset=utf-8";
                response.StatusCode = 200;
                response.OutputStream.Close();
            }
            else if (path == "/Cambio/USD")
            {
                var controller = new CambioController();
                var paginaConteudo = controller.USD();
                var bufferArquivo = Encoding.UTF8.GetBytes(paginaConteudo);

                response.OutputStream.Write(bufferArquivo, 0, bufferArquivo.Length);
                response.ContentType = "text/html; charset=utf-8";
                response.StatusCode = 200;
                response.OutputStream.Close();
            }

            httpListener.Stop();
        }
    }
}
