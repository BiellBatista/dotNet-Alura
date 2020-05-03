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
