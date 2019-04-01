using System;
using Xunit;

namespace Elevador.Testes.Unidade
{
    public class ControleDoElevadorTestes
    {
        [Fact]
        public void ElevadorParadoNo1ºAndarDevePoderSubirAteO4ºAndar()
        {
            var andaresDoPredio = 5;
            var andarInicial = 1;
            var andarDesejado = 4;
            var controleElevador = new ControleElevador(andaresDoPredio);
            var elevadorParado = new ElevadorParado(andarInicial, controleElevador);

            var elevadorSubindo = new ElevadorSubindo(andarDesejado, elevadorParado);
            var resultado = elevadorSubindo.MovimentarElevador();

            Assert.Equal("Parado no 4º andar.", resultado);
        }

        [Fact]
        public void ElevadorParadoNo5ºAndarDevePoderDescerAteO1ºAndar()
        {
            var andaresDoPredio = 5;
            var andarInicial = 5;
            var andarDesejado = 1;
            var controleElevador = new ControleElevador(andaresDoPredio);
            var elevadorParado = new ElevadorParado(andarInicial, controleElevador);

            var elevadorDescendo = new ElevadorDescendo(andarDesejado, elevadorParado);
            var resultado = elevadorDescendo.MovimentarElevador();

            Assert.Equal("Parado no 1º andar.", resultado);
        }

        [Fact]
        public void ElevadorNaoDeveSubirMaisDoQueOLimiteDoPredio()
        {
            var andaresDoPredio = 5;
            var andarInicial = 1;
            var andarDesejado = 6;
            var controleElevador = new ControleElevador(andaresDoPredio);
            var elevadorParado = new ElevadorParado(andarInicial, controleElevador);

            var elevadorSubindo = new ElevadorSubindo(andarDesejado, elevadorParado);
            var resultado = elevadorSubindo.MovimentarElevador();

            Assert.Equal("Andar inválido.", resultado);
        }

        [Fact]
        public void ElevadorNaoDeveDescerAlemDoPrimeiroAndar()
        {
            var andaresDoPredio = 5;
            var andarInicial = 1;
            var andarDesejado = -1;
            var controleElevador = new ControleElevador(andaresDoPredio);
            var elevadorParado = new ElevadorParado(andarInicial, controleElevador);

            var elevadorDescendo = new ElevadorDescendo(andarDesejado, elevadorParado);
            var resultado = elevadorDescendo.MovimentarElevador();

            Assert.Equal("Andar inválido.", resultado);
        }

        [Fact]
        public void ElevadorNaoDeveIniciarEmUmAndarAlemDoLimiteDoPredio()
        {
            var andaresDoPredio = 5;
            var andarInicial = 6;
            var controleElevador = new ControleElevador(andaresDoPredio);

            Assert.Throws<IndexOutOfRangeException>(() => new ElevadorParado(andarInicial, controleElevador));
        }
    }
}
