﻿using _09_XX_XX_EntradaSaídaStreams.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_XX_XX_EntradaSaídaStreams
{
    /**
     * Esta classe faz parte da class Program, com o modificado partial é possível dividir uma classe em dois arquivos
     */
    partial class Program
    {
        static void Main(string[] args)
        {
            LeituraBinaria();
            //EscritaBinaria();
            //using (var fs = new FileStream("testaTipos.txt", FileMode.Create))
            //using (var escritor = new StreamWriter(fs))
            //{
            //    escritor.WriteLine(true);
            //    escritor.WriteLine(false);
            //    escritor.WriteLine(45649845120);
            //}

            //LidandoComFileStreamDiretamente(); //Este método está em outro arquivo, mas ambos são a classe Program
            //CriarArquivo(); //Este método está em outro arquivo, mas ambos são a classe Program
            //CiarArquivoComWriter(); //Este método está em outro arquivo, mas ambos são a classe Program
            //TestaEscrita();

            Console.ReadLine();
        }
    }
}