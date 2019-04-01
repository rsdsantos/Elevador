using System;

namespace Elevador
{
    class Program
    {
        static int _andaresDoPredio => 10;

        static void Main(string[] args)
        {
            var controle = new ControleElevador(_andaresDoPredio);

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Bem vindo ao software de elevador mais simples do mundo!");
            Console.WriteLine("Digite 0 a qualquer momento para sair!");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"Considere que o prédio tem {_andaresDoPredio} andares.");            

            controle.IniciarElevador();
        }        
    }
}
