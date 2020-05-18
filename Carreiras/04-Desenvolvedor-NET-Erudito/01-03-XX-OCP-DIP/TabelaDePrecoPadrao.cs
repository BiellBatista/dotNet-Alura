﻿namespace _01_03_XX_OCP_DIP
{
    public class TabelaDePrecoPadrao : ITabelaDePreco
    {
        public double DescontoPara(double valor)
        {
            if (valor > 5000) return 0.03;
            if (valor > 1500) return 0.05;
            return 0;
        }
    }
}
