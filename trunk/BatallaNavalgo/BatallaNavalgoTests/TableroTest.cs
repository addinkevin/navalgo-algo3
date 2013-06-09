using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using NUnit.Framework;

namespace BatallaNavalgoTests
{
    [TestFixture]
    class TableroTest
    {
        [Test]
        public void testDeberiaEstarVacioEnElMomentoDeLaCreacion()
        {
            Tablero tablero = new Tablero();

            Assert.True(tablero.EstaVacio());
        }

        [Test]
        public void testDeberiaNoEstarVacioCuandoSeAgregaAlgo()
        {
            Tablero tablero = new Tablero();
            tablero.AgregarNave(new Nave(1, 1, new Posicion(1, 1), Nave.HORIZONTAL));

            Assert.False(tablero.EstaVacio());
        }

        [Test]
        public void testDeberiaHaberNaveEnUnaPosicionLuegoDeQueSeAgrego()
        {
            Tablero tablero = new Tablero();
            tablero.AgregarNave(new Nave(1, 1, new Posicion(1, 1), Nave.HORIZONTAL));

            Assert.True(tablero.HayNave(new Posicion(1, 1)));
        }

        [Test]
        public void testDeberiaHaberArmamentoEnUnaPosicionLuegoDeQueSeAgrego()
        {
            Tablero tablero = new Tablero();
            Armamento mina = ArmamentoFactory.CrearMinaPorContacto(new Posicion(3, 3));
            tablero.Impactar(mina);

            Assert.True(tablero.HayMina(new Posicion(3, 3)));
        }

        [Test]
        public void testDeberiaActualizarseLaPosicionDeLaNave()
        {
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, new Posicion(5, 5), Nave.VERTICAL);
            nave.SetDireccion(new Direccion(1, 0));
            tablero.AgregarNave(nave);
            tablero.Actualizar();

            Assert.True(tablero.HayNave(new Posicion(6, 5)));
        }

        [Test]
        public void testDeberiaHaberUnaNaveEnUnaPosicionLuegoDeAgregarla()
        {
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, new Posicion(5, 5), Nave.VERTICAL);
            tablero.AgregarNave(nave);
            List<Nave> naves = tablero.GetNavesEn(new Posicion(5, 5));

            Assert.AreEqual(nave, naves[0]);
        }
    }
}