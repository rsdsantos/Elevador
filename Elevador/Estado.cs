namespace Elevador
{
    public abstract class Estado
    {
        public ControleElevador Elevador { get; set; }
        public int AndarAtual { get; set; }
        public int AndarDesejado { get; set; }
        public bool[] Controle { get; set; }

        public abstract string MovimentarElevador();

        public string PararNoAndar(int andarDesejado)
        {
            Controle[AndarAtual] = false;
            Controle[andarDesejado] = true;
            AndarAtual = andarDesejado;

            return ($"Parado no {andarDesejado}º andar.");
        }
    }
}
