﻿using System;

namespace _01_05_Criar_Metodos_Sobrecarregados_Substituidos.Depois
{
    class TiposDeValor : IAulaItem
    {
        public void Executar()
        {
            int idade;
            idade = 30;
            Console.WriteLine(idade);

            int copiaIdade = idade;

            Console.WriteLine($"idade: {idade}");
            Console.WriteLine($"copiaIdade: {copiaIdade}");

            idade = 23;

            Console.WriteLine($"idade: {idade}");
            Console.WriteLine($"copiaIdade: {copiaIdade}");

            int? idade2 = null;
            System.Nullable<int> idade3 = null;
        }
    }
}
