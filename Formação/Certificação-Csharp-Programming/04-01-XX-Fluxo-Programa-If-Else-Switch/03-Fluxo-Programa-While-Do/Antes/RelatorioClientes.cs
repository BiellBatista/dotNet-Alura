﻿using System;
using System.IO;

namespace _04_01_XX_Fluxo_Programa_If_Else_Switch.Antes
{
    class RelatorioClientes
    {
        public static void ImprimirListagemClientes()
        {
            using (var leitor = new StreamReader("Clientes.txt"))
            {
                //imprime cabeçalho
                Console.WriteLine("id,nome,sobrenome,email,valor,status");

                //lê primeira linha de dados
                string linha = leitor.ReadLine();
                //verifica fim de arquivo
                if (linha != null)
                {
                    //imprime a linha do cliente
                    var campos = linha.Split(',');
                    Console.WriteLine(
                        $"{int.Parse(campos[0])}, {campos[1]}" +
                        $", {campos[2]}, {campos[3]}" +
                        $", {decimal.Parse(campos[4])}, {campos[5]}");
                }
            }
        }
    }
}
