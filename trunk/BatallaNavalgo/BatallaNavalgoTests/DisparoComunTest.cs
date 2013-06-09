using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using NUnit.Framework;

namespace BatallaNavalgoTests
{
    [TestFixture]
    class DisparoComunTest
    {
        [Test]
        public void testDeberiaNoEstarExplotadoAlCrearlo()
        {
            DisparoComun disparo = new DisparoComun();

            Assert.False(disparo.EstaExplotado());
        }
        [Test]
        public void testDeberiaEstarExplotadoCuandoLoActualizo()
        {
            DisparoComun disparo = new DisparoComun();
            disparo.SetPosicion(new Posicion(3, 3));
            disparo.SetTablero(new Tablero());

            disparo.Actualizar();

            Assert.True(disparo.EstaExplotado());

        }

        [Test]
        public void testDeberiaAtacarALaNaveSoloUnaVez()
        {
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 2, new Posicion(1, 1), Nave.VERTICAL);
            tablero.AgregarNave(nave);
            DisparoComun disparo = new DisparoComun();
            disparo.SetTablero(tablero);
            disparo.SetPosicion(new Posicion(1, 1));

            disparo.Actualizar();
            disparo.Actualizar();

            // Es una nave de una parte con resistencia dos. Solo recibio un disparo. No debe estar destruida.
            Assert.False(nave.EstaDestruida());
        }
    }
}
