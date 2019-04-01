namespace Elevador
{
    public class ElevadorDescendo : Estado
    {
        private readonly int _andarDesejado;

        public ElevadorDescendo(int andarDesejado, Estado estado)
            :this(estado.AndarAtual, estado.Controle, estado.Elevador)
        {
            _andarDesejado = andarDesejado;
        }

        private ElevadorDescendo(int andarAtual, bool[] controle, ControleElevador elevador)
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

            for (int i = AndarAtual; i >= 1; i--)
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
