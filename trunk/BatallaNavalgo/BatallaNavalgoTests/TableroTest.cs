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
    class TableroTest
    {
        [Test]
        public void testDeberiaHaberNaveEnUnaPosicionLuegoDeQueSeAgrego()
        {
            Tablero tablero = new Tablero();
            tablero.AgregarNave(new Nave(1, 1, new Posicion(1, 1), Orientacion.Horizontal,Direccion.Noreste));

            Assert.True(tablero.HayNave(new Posicion(1, 1)));
        }

        [Test]
        public void testNoDeberiaHaberNaveEnUnaPosicionSiNoSeLaAgrego()
        {
            Tablero tablero = new Tablero();            

            Assert.False(tablero.HayNave(new Posicion(1, 1)));
        }

        [Test]
        public void testDeberiaActualizarseLaPosicionDeLaNave()
        {
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, new Posicion(5, 5), Orientacion.Vertical,Direccion.Sur);            
            tablero.AgregarNave(nave);
            
            tablero.Actualizar();

            Assert.True(tablero.HayNave(new Posicion(6, 5)));
        }

        [Test]
        public void testDeberiaHaberUnaNaveEnUnaPosicionLuegoDeAgregarla()
        {
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, new Posicion(5, 5), Orientacion.Vertical, Direccion.Este);
            tablero.AgregarNave(nave);
            
            List<Nave> naves = tablero.GetNavesEn(new Posicion(5, 5));

            Assert.AreEqual(nave, naves[0]);
        }

        [Test]
        public void testDeberiaTenerLaNaveConVidaSiNoSeLaAtaco()
        {
            Tablero tablero = new Tablero();
            tablero.AgregarNave(NaveFactory.CrearLancha());

            Assert.True(tablero.TieneNavesConVida());
        }
        [Test]
        public void testDeberiaNoTenerNaveConVidaSiLaAtaco()
        {
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, new Posicion(3, 3), Orientacion.Horizontal, Direccion.Sur);            
            tablero.AgregarNave(nave);
            DisparoComun disparo = ArmamentoFactory.CrearDisparoComun(new Tablero(), new Posicion(3, 3));
            disparo.TableroEnElQueEsta = (tablero);

            tablero.Impactar(disparo);
            tablero.Actualizar();

            Assert.False(tablero.TieneNavesConVida());
        }
        [Test,ExpectedException(typeof(ArmamentoFueraDelTableroException))]
        public void testDeberiaLanzarExcepcionSiPongoUnArmamentoQueNoEstaDentroDelTablero()
        {
            Tablero tablero = new Tablero();

            Armamento armamento = new MinaConRetardo(tablero, new Posicion(0, 0), 100, 1, 1);

            // Debe lanzar excepcion.
            tablero.Impactar(armamento);
        }
    }
}