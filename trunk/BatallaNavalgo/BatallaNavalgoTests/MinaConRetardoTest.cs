using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using NUnit.Framework;

namespace BatallaNavalgoTests
{
    [TestFixture]
    class MinaConRetardoTest
    {
        [Test]
        public void testDeberiaNoEstarExplotadaAlCrearla()
        {
            MinaConRetardo mina = new MinaConRetardo(1, 1);

            Assert.False(mina.EstaExplotado());
        }

        [Test]
        public void testDeberiaEstarExplotadaSiLaActualizoTantasVecesComoSuRetardo()
        {
            MinaConRetardo mina = new MinaConRetardo(1, 2);
            mina.SetTablero(new Tablero());

            mina.Actualizar();
            mina.Actualizar();

            Assert.True(mina.EstaExplotado());
        }

        [Test]
        public void testSiHayNaveEnSuRadioDeAlcanceDeberiaDañarla()
        {
            Tablero tablero = new Tablero();
            MinaConRetardo mina = new MinaConRetardo(1, 1);
            Posicion posicionMina = new Posicion(3, 3);
            Posicion posicionNave = new Posicion(2, 3);
            Nave nave = new Nave(1, 1, posicionNave, Nave.HORIZONTAL);
            mina.SetTablero(tablero);
            tablero.AgregarNave(nave);

            mina.SetPosicion(posicionMina);
            mina.Actualizar();

            Assert.True(nave.EstaDestruida());
        }
    }
}
