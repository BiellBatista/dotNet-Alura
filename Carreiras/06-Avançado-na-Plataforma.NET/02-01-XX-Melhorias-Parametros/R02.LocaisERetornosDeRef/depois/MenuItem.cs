﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _02_01_XX_Melhorias_Parametros.R02.depois
{
    class MenuItem : _02_01_XX_Melhorias_Parametros.MenuItem
    {
        public override void Main()
        {
            int[] numeros = { 2, 7, 1, 9, 12, 8, 15 };
            int indice = LocalizarIndice(12, numeros);
            numeros[indice] = -12;
            WriteLine(numeros[4]);
        }

        public int LocalizarIndice(int valor, int[] numeros)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] == valor)
                {
                    return i;
                }
            }

            throw new IndexOutOfRangeException("Não encontrado!");
        }
    }
}
