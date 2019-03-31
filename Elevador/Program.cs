using System;

namespace Elevador
{
    class Program
    {
        static int _andaresDoPredio => 10;
        static ControleElevador _controle;

        static void Main(string[] args)
        {
            _controle = new ControleElevador(_andaresDoPredio);

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Bem vindo ao software de elevador mais simples do mundo!");
            Console.WriteLine("      [ Digite 0 a qualquer momento para sair! ]");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"Considere que o prédio tem {_andaresDoPredio} andares.");

            Inicio:
            Console.WriteLine("");
            Console.WriteLine($"Para qual andar você deseja ir?");            

            var andarDesejado = ValidarEntrada();

            _controle.IrParaAndar(andarDesejado);
            goto Inicio;
        }

        private static int ValidarEntrada()
        {
            var resultado = default(int);
            var andar = Console.ReadLine();

            if (andar == "0")
                Environment.Exit(0);

            else if (!int.TryParse(andar, out resultado))
                AndarInvalido();                             

            return resultado;
        }

        private static void AndarInvalido()
        {
            Console.WriteLine("Andar inválido. Informe novamente o andar que deseja ir.");
            ValidarEntrada();
        }
    }
}
