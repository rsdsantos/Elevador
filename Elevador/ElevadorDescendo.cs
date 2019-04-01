namespace Elevador
{
    public class ElevadorDescendo : Estado
    {
        public ElevadorDescendo(Estado estado)
            :this(estado.AndarAtual, estado.AndarDesejado, estado.Controle, estado.Elevador)
        {            
        }

        public ElevadorDescendo(int andarAtual, int andarDesejado, bool[] controle, ControleElevador elevador)
        {
            AndarAtual = andarAtual;
            AndarDesejado = andarDesejado;
            Controle = controle;
            Elevador = elevador;
        }

        public override string MovimentarElevador()
        {
            var mensagem = string.Empty;

            for (int i = AndarAtual; i >= 1; i--)
            {
                if (Controle[i])
                {
                    mensagem = PararNoAndar(AndarDesejado);
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
