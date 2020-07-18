﻿namespace _04_09_XX_Facades_Singletons.Command
{
    public class PagaPedido : IComando
    {
        public Pedido Pedido { get; private set; }

        public PagaPedido(Pedido pedido)
        {
            Pedido = pedido;
        }

        public void Executa()
        {
            System.Console.WriteLine("Pagando o pedido do cliente {0}", Pedido.Cliente);
            Pedido.Paga();
        }
    }
}
