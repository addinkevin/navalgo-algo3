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

        [Test]
        public void deberiaLaNaveEstarNoDestruidaAlMomentoDeSuCreacion()
        {
            Nave nave = new Nave(3, 3, new Posicion(1, 1), Nave.VERTICAL);
            Assert.False(nave.EstaDestruida());
        }

        [Test]
        public void deberiaNaveDeUnaParteSeguirNoDestruidaSiTieneResistenciaMayorAUnoYRecibeDisparo()
        {
            Nave nave = new Nave(1, 2, new Posicion(1, 1), Nave.VERTICAL);
            nave.RecibirAtaque(new DisparoComun(new Posicion(1,1)));

            Assert.False(nave.EstaDestruida());

        }

        [Test]
        public void deberiaDestruirLaNaveDeUnaParteSiTieneResistenciaDosYRecibeDosDisparos()
        {
            Nave nave = new Nave(1, 2, new Posicion(1, 1), Nave.VERTICAL);

            nave.RecibirAtaque(new DisparoComun(new Posicion(1,1)));
            nave.RecibirAtaque(new DisparoComun(new Posicion(1,1)));

            Assert.True(nave.EstaDestruida());
        }

        [Test]
        public void testMoverUnaNaveDadaUnaDireccion()
        {
            Nave nave = new Nave(2, 1, new Posicion(5, 5), Nave.VERTICAL);
            nave.SetDireccion(new Direccion(1, 0));

            nave.Mover();
            List<Posicion> posiciones = nave.GetPosiciones();

            Assert.True(posiciones[0].EsIgualA(new Posicion(6, 5)));
            Assert.True(posiciones[1].EsIgualA(new Posicion(7, 5)));
        }

        [Test]
        public void testMoverNaveHaciaPosicionFueraDeRangoYVerQueSeMueveASentidoContrario()
        {
            // Posicion de la nave: (9,9) y (10,9)
            Nave nave = new Nave(2, 1, new Posicion(9, 9), Nave.VERTICAL);
            nave.SetDireccion(new Direccion(1, 0));

            // Deberia Moverse invirtiendo sentido, ya que se va del tablero.
            nave.Mover();
            List<Posicion> posiciones = nave.GetPosiciones();

            Assert.True(posiciones[0].EsIgualA(new Posicion(8, 9)));
            Assert.True(posiciones[1].EsIgualA(new Posicion(9, 9)));
            
        }
    }
}
