﻿namespace _04_05_XX_Visitor.Interpreter
{
    public class Subtracao : IExpressao
    {
        private IExpressao esquerda;
        private IExpressao direita;

        public Subtracao(IExpressao esquerda, IExpressao direita)
        {
            this.esquerda = esquerda;
            this.direita = direita;
        }

        public int Avalia()
        {
            int resultadoDaEsquerda = esquerda.Avalia();
            int resultadoDaDireita = direita.Avalia();
            return resultadoDaEsquerda - resultadoDaDireita;
        }
    }
}
