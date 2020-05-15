using System;

namespace _01_01_XX_Coesao_S
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculadora = new CalculadoraDeSalario();
            var funcionario = new Funcionario(new Desenvolvedor(new DezOuVintePorcento()), 2000);

            double resultado = calculadora.Calcular(funcionario);

            Console.WriteLine("O salario de um desenvolvedor que ganha 2000 bruto eh: " + resultado);
            Console.ReadKey();
        }
    }
}

/**
 * Podemos pensar sobre coes�o em v�rios n�veis diferentes. Por exemplo, o que seria uma interface coesa? Uma interface coesa � aquela que tamb�m
 * s� possui uma �nica responsabilidade.

E ser� que conseguimos ver a coes�o pelo outro lado? Pense, se a classe A depende de B, idealmente B deve prover uma interface para A, somente
    com as coisas que A depende. Ou seja, a classe n�o deve depender de m�todos que ela n�o usa. Isso � o que chamamos de Princ�pio de Segrega��o
    de Interfaces, ou ISP.
 */
