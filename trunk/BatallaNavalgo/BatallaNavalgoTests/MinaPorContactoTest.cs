using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using NUnit.Framework;

namespace BatallaNavalgoTests
{
    [TestFixture]
    class MinaPorContactoTest
    {
        [Test]
        public void testDeberiaNoEstarExplotadaAlCrearla()
        {
            MinaPorContacto mina = new MinaPorContacto();
            Assert.False(mina.EstaExplotado());            
        }

        [Test]
        public void NoDeberiaExplotarAlActualizar()
        {
            MinaPorContacto mina = new MinaPorContacto();
            mina.Actualizar();
            Assert.False(mina.EstaExplotado());
        }

        [Test]
        public void DeberiaExplotarSiSuPosicionCoincideConLaDeUnaNave()
        {
            MinaPorContacto mina = new MinaPorContacto();
            Posicion posicion = new Posicion(5,5);
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, posicion, 0);
            tablero.AgregarNave(nave);
            mina.SetPosicion(posicion);
            mina.SetTablero(tablero);

            mina.Actualizar();
            Assert.True(mina.EstaExplotado());
        }



    }
}
