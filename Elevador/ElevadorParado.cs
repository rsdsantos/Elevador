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

            var andarDesejado = Elevador.ValidarEntrada();

            if (AndarAtual < andarDesejado)
            {
                Elevador.EstadoAtual = new ElevadorSubindo(andarDesejado, this);
                return "Elevador subindo...";
            }
            else if (AndarAtual > andarDesejado)
            {
                Elevador.EstadoAtual = new ElevadorDescendo(andarDesejado, this);
                return "Elevador descendo...";
            }
            else
                return "O elevador já encontra-se no andar.";
        }
    }
}
