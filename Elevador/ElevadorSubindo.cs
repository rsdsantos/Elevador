namespace Elevador
{
    public class ElevadorSubindo : Estado
    {
        private readonly int _andarDesejado; 

        public ElevadorSubindo(int andarDesejado, Estado estado)
            :this(estado.AndarAtual, estado.Controle, estado.Elevador)
        {
            _andarDesejado = andarDesejado;
        }

        private ElevadorSubindo(int andarAtual, bool[] controle, ControleElevador elevador)
        {
            AndarAtual = andarAtual;
            Controle = controle;
            Elevador = elevador;
        }

        public override string MovimentarElevador()
        {
            var mensagem = string.Empty;

            if (_andarDesejado < 1 || _andarDesejado > Elevador.ObterAndares())
                return "Andar inválido.";

            for (int i = AndarAtual; i <= Elevador.ObterAndares(); i++)
            {
                if (Controle[i])
                {
                    mensagem = PararNoAndar(_andarDesejado);
                    Elevador.EstadoAtual = new ElevadorParado(this);
                    break;
                }                  
                else
                    continue;
            }

            return mensagem ?? "Andar não encontrado!";
        }
    }
}
