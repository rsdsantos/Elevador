using System;

namespace Elevador
{
    public class ElevadorParado : Estado
    {
        public ElevadorParado(Estado estado)
            : this(estado.AndarAtual, estado.Elevador)
        {
        }

        public ElevadorParado(int andarAtual, ControleElevador elevador)
        {
            AndarAtual = andarAtual;
            Elevador = elevador;
            Controle = new bool[elevador.ObterAndares() + 1];

            Controle[andarAtual] = true;
        }

        public override string MovimentarElevador()
        {
            Console.WriteLine("");
            Console.WriteLine($"Para qual andar você deseja ir?");

            AndarDesejado = Elevador.ValidarEntrada();       

            if (AndarAtual < AndarDesejado)
            {
                Elevador.EstadoAtual = new ElevadorSubindo(this);
                return "Elevador subindo...";
            }
            else if (AndarAtual > AndarDesejado)
            {
                Elevador.EstadoAtual = new ElevadorDescendo(this);
                return "Elevador descendo...";
            }
            else
                return "O elevador já se encontra no andar.";
        }
    }
}
