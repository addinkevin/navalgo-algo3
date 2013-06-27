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
            Nave nave = new Nave(2, 1, new Posicion(3, 3), Orientacion.Horizontal);
            List<Posicion> posiciones = nave.GetPosiciones();

            Posicion pos1 = posiciones[0];
            Posicion pos2 = posiciones[1];

            Assert.True(pos1.EsIgualA(new Posicion(3,3)));
            Assert.True(pos2.EsIgualA(new Posicion(3,4)));
            
        }
        [Test]
        public void testCrearNaveVerticalDadaUnaPosicionInicialYVerificar()
        {
            Nave nave = new Nave(2, 1, new Posicion(4, 3), Orientacion.Vertical);
            List<Posicion> posiciones = nave.GetPosiciones();

            Posicion pos1 = posiciones[0];
            Posicion pos2 = posiciones[1];

            Assert.True(pos1.Fila == 4 && pos1.Columna == 3);
            Assert.True(pos2.Fila == 5 && pos2.Columna == 3);

        }

        [Test, ExpectedException(typeof(ImposibleCrearNaveException))]
        public void testDeberiaLanzarExcepcionAlCrearUnaNaveFueraDelTablero()
        {
            Nave nave = new Nave(2, 2, new Posicion(100, 100), Orientacion.Vertical);
        }

        [Test, ExpectedException(typeof(ImposibleCrearNaveException))]
        public void testDeberiaLanzarExcepcionSiQuedaAlgunaParteFueraDelTablero()
        {
            Nave nave = new Nave(10, 3, new Posicion(6, 6), Orientacion.Vertical);
        }

        [Test]
        public void deberiaLaNaveEstarNoDestruidaAlMomentoDeSuCreacion()
        {
            Nave nave = new Nave(3, 3, new Posicion(1, 1), Orientacion.Vertical);
            Assert.False(nave.EstaDestruida());
        }

        [Test]
        public void deberiaNaveDeUnaParteSeguirNoDestruidaSiTieneResistenciaMayorAUnoYRecibeDisparo()
        {
            Nave nave = new Nave(1, 2, new Posicion(1, 1), Orientacion.Vertical);
            DisparoComun disparo = ArmamentoFactory.CrearDisparoComun(new Tablero(), new Posicion(1, 1));
            nave.RecibirAtaque(disparo, disparo.Posicion);

            Assert.False(nave.EstaDestruida());

        }

        [Test]
        public void deberiaDestruirLaNaveDeUnaParteSiTieneResistenciaDosYRecibeDosDisparos()
        {
            Nave nave = new Nave(1, 2, new Posicion(1, 1), Orientacion.Vertical);

            DisparoComun disparo = ArmamentoFactory.CrearDisparoComun(new Tablero(),new Posicion(1, 1));
            
            nave.RecibirAtaque(disparo,disparo.Posicion);
            nave.RecibirAtaque(disparo, disparo.Posicion);

            Assert.True(nave.EstaDestruida());
        }

        [Test]
        public void deberiaDestruirLaNaveDeUnaParteSiTieneResistenciaDosYRecibeDosMinasDeAtaque()
        {
            Nave nave = new Nave(1, 2, new Posicion(1, 1), Orientacion.Vertical);

            Mina mina = ArmamentoFactory.CrearMinaPorContacto(new Tablero(), new Posicion(1, 1));
            nave.RecibirAtaque(mina, mina.Posicion);
            nave.RecibirAtaque(mina, mina.Posicion);

            Assert.True(nave.EstaDestruida());
        }

        [Test]
        public void testMoverUnaNaveDadaUnaDireccion()
        {
            Nave nave = new Nave(2, 1, new Posicion(5, 5), Orientacion.Vertical);
            nave.Direccion = (Direccion.Sur);

            nave.Mover();
            List<Posicion> posiciones = nave.GetPosiciones();

            Assert.True(posiciones[0].EsIgualA(new Posicion(6, 5)));
            Assert.True(posiciones[1].EsIgualA(new Posicion(7, 5)));
        }

        [Test]
        public void testMoverNaveVerticalHaciaPosicionFueraDeRangoYVerQueSeMueveASentidoContrario()
        {
            // Posicion de la nave: (9,9) y (10,9)
            Nave nave = new Nave(2, 1, new Posicion(9, 9), Orientacion.Vertical);
            nave.Direccion = (Direccion.Sur);

            // Deberia Moverse invirtiendo sentido, ya que se va del tablero.
            nave.Mover();
            List<Posicion> posiciones = nave.GetPosiciones();

            Assert.True(posiciones[0].EsIgualA(new Posicion(8, 9)));
            Assert.True(posiciones[1].EsIgualA(new Posicion(9, 9)));
        }
        [Test]
        public void testMoverNaveHorizontalHaciaPosicionFueraDeRangoYVerQueSeMueveASentidoContrario()
        {
            // Posicion de la nave: (9,9) y (9,10)
            Nave nave = new Nave(2, 1, new Posicion(9, 9), Orientacion.Horizontal);
            nave.Direccion = (Direccion.Este); // Aumenta columna +1.

            // Deberia Moverse invirtiendo sentido, ya que se va del tablero.
            nave.Mover();
            List<Posicion> posiciones = nave.GetPosiciones();

            Assert.True(posiciones[0].EsIgualA(new Posicion(9, 8)));
            Assert.True(posiciones[1].EsIgualA(new Posicion(9, 9)));
        }

        [Test]
        public void testDeberiaNoMoverseSiEstaEstancadaEnUnaPosicionDebidoASuDireccion()
        {
            // Posicion de la nave: (10,9) y (10,10)
            Nave nave = new Nave(2, 1, new Posicion(10, 9), Orientacion.Horizontal);
            nave.Direccion = (Direccion.Noreste); // Aumenta columna +1 Fila -1.

            nave.Mover();
            List<Posicion> posiciones = nave.GetPosiciones();

            Assert.True(posiciones[0].EsIgualA(new Posicion(10, 9)));
            Assert.True(posiciones[1].EsIgualA(new Posicion(10, 10)));

        }

        [Test]
        public void testAtacarALaNaveConUnDisparoEnUnaDeSusPartesYVerificarQueEsteDestruida()
        {
            Nave nave = new Nave(3, 1, new Posicion(1,1), Orientacion.Vertical);
            DisparoComun disparo = new DisparoComun(new Tablero(), new Posicion(2,1), 100);

            nave.RecibirAtaque(disparo, disparo.Posicion);

            Assert.True(nave.EstaDestruidaEnLaPosicion(new Posicion(2,1)));
        }

        [Test]
        public void testDeberiaPoderCrearLaNaveEnElCentroDelTablero()
        {
            int cantidadDePartes = 3;
            Orientacion orientacion = Orientacion.Vertical;

            Assert.True(Nave.SePuedeCrear(cantidadDePartes, new Posicion(4,4), orientacion));
        }
    }
}
