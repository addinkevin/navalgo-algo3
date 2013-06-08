using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using BatallaNavalgoExcepciones;
using NUnit.Framework;

namespace BatallaNavalgoTests
{
    [TestFixture]
    class NaveTest
    {
        [Test]
        public void testCrearNaveHorizontalDadaUnaPosicionInicialYVerificar()
        {
            Nave nave = new Nave(2, 1, new Posicion(3, 3), Nave.HORIZONTAL);
            List<Posicion> posiciones = nave.GetPosiciones();

            Posicion pos1 = posiciones[0];
            Posicion pos2 = posiciones[1];

            Assert.True(pos1.GetFila() == 3 && pos1.GetColumna() == 3);
            Assert.True(pos2.GetFila() == 3 && pos2.GetColumna() == 4);
            
        }
        [Test]
        public void testCrearNaveVerticalDadaUnaPosicionInicialYVerificar()
        {
            Nave nave = new Nave(2, 1, new Posicion(4, 3), Nave.VERTICAL);
            List<Posicion> posiciones = nave.GetPosiciones();

            Posicion pos1 = posiciones[0];
            Posicion pos2 = posiciones[1];

            Assert.True(pos1.GetFila() == 4 && pos1.GetColumna() == 3);
            Assert.True(pos2.GetFila() == 5 && pos2.GetColumna() == 3);

        }

        [Test, ExpectedException(typeof(ImposibleCrearNaveException))]
        public void testDeberiaLanzarExcepcionAlCrearUnaNaveFueraDelTablero()
        {
            Nave nave = new Nave(2, 2, new Posicion(100, 100), Nave.VERTICAL);
        }

        [Test, ExpectedException(typeof(ImposibleCrearNaveException))]
        public void testDeberiaLanzarExcepcionSiQuedaAlgunaParteFueraDelTablero()
        {
            Nave nave = new Nave(10, 3, new Posicion(6, 6), Nave.VERTICAL);
        }


    }
}
