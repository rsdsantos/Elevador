namespace Elevador
{
    public class ElevadorSubindo : Estado
    {
        public ElevadorSubindo(Estado estado)
            :this(estado.AndarAtual, estado.AndarDesejado, estado.Controle, estado.Elevador)
        {            
        }

        public ElevadorSubindo(int andarAtual, int andarDesejado, bool[] controle, ControleElevador elevador)
        {
            AndarAtual = andarAtual;
            AndarDesejado = andarDesejado;
            Controle = controle;
            Elevador = elevador;
        }

        public override string MovimentarElevador()
        {
            var mensagem = string.Empty;

            for (int i = AndarAtual; i <= Elevador.ObterAndares(); i++)
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
