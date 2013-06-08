using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using NUnit.Framework;


namespace BatallaNavalgoTests
{
    [TestFixture]
    class PosicionTest
    {
        [Test]
        public void testCrearUnaPosicionYObtenerFilaYColumna()
        {
            Posicion posicion = new Posicion(3, 6);
            Assert.AreEqual(3, posicion.GetFila());
            Assert.AreEqual(6, posicion.GetColumna());
        }

        [Test]
        public void testDeberiaEstarEnElRangoEspecificado()
        {
            Posicion posicion = new Posicion(3, 6);
            Posicion posLimite1 = new Posicion(0, 0);
            Posicion posLimite2 = new Posicion(7, 7);
            Assert.IsTrue(posicion.EstaDentroDe(posLimite1, posLimite2));
        }

        [Test]
        public void testVerificarIgualdadDePosiciones()
        {
            Posicion posicion = new Posicion(3, 4);
            Posicion otraPosicion = new Posicion(3, 4);

            Assert.True(posicion.EsIgualA(otraPosicion));
        }
    }
}