using System;

namespace Elevador
{
    public class ControleElevador
    {
        private int _andarAtual;
        private readonly bool[] _controle;
        private readonly int _andaresDoPredio;

        public ControleElevador(int andaresDoPredio)
        {            
            _andaresDoPredio = andaresDoPredio;
            _controle = new bool[andaresDoPredio + 1];
            _andarAtual = 1; // O primeiro andar será considerado padrão.             
        }

        public void IrParaAndar(int andarPressionado)
        {
            if (andarPressionado < 1 || andarPressionado > _andaresDoPredio)
            {
                Console.WriteLine($"Este elevador só vai do 1º ao {_andaresDoPredio}º andar.");
                return;
            }                

            _controle[andarPressionado] = true;

            if (_andarAtual < andarPressionado)
                SubirParaAndar(andarPressionado);

            else if (_andarAtual == andarPressionado)
                JaEstaNoAndar();

            else
                DescerParaAndar(andarPressionado);
        }

        private void JaEstaNoAndar()
        {
            Console.WriteLine("O elevador já está no andar escolhido.");
        }

        private void DescerParaAndar(int andarPressionado)
        {
            Console.WriteLine("Elevador descendo...");

            for (int i = _andarAtual; i >= 1; i--)
            {
                if (_controle[i])
                {
                    PararNoAndar(andarPressionado);
                    break;
                }                    
                else
                    continue;
            }      
        }

        private void SubirParaAndar(int andarPressionado)
        {
            Console.WriteLine("Elevador subindo...");

            for (int i = _andarAtual; i <= _andaresDoPredio; i++)
            {
                if (_controle[i])
                {
                    PararNoAndar(andarPressionado);
                    break;
                }                    
                else
                    continue;
            }
        }

        private void PararNoAndar(int andarPressionado)
        {
            _andarAtual = andarPressionado;
            _controle[andarPressionado] = false;

            Console.WriteLine($"Parado no {andarPressionado}º andar.");
        }
    }
}
