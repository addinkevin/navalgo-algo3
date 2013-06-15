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
            tablero.AgregarNave(new Nave(1, 1, new Posicion(1, 1), Orientacion.Horizontal));

            Assert.False(tablero.EstaVacio());
        }

        [Test]
        public void testDeberiaHaberNaveEnUnaPosicionLuegoDeQueSeAgrego()
        {
            Tablero tablero = new Tablero();
            tablero.AgregarNave(new Nave(1, 1, new Posicion(1, 1), Orientacion.Horizontal));

            Assert.True(tablero.HayNave(new Posicion(1, 1)));
        }

        [Test]
        public void testNoDeberiaHaberNaveEnUnaPosicionSiNoSeLaAgrego()
        {
            Tablero tablero = new Tablero();            

            Assert.False(tablero.HayNave(new Posicion(1, 1)));
        }

        [Test]
        public void testDeberiaHaberArmamentoEnUnaPosicionLuegoDeQueSeAgrego()
        {
            Tablero tablero = new Tablero();
            Armamento mina = ArmamentoFactory.CrearMinaPorContacto(new Tablero(), new Posicion(3, 3));
            tablero.Impactar(mina);

            Assert.True(tablero.HayMina(new Posicion(3, 3)));
        }

        [Test]
        public void testNoDeberiaHaberArmamentoEnUnaPosicionSiNoSeLoAgrego()
        {
            Tablero tablero = new Tablero();                        

            Assert.False(tablero.HayMina(new Posicion(3, 3)));
        }

        [Test]
        public void testDeberiaActualizarseLaPosicionDeLaNave()
        {
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, new Posicion(5, 5), Orientacion.Vertical);
            nave.Direccion = (new Direccion(1, 0));
            tablero.AgregarNave(nave);
            
            tablero.Actualizar();

            Assert.True(tablero.HayNave(new Posicion(6, 5)));
        }

        [Test]
        public void testDeberiaHaberUnaNaveEnUnaPosicionLuegoDeAgregarla()
        {
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, new Posicion(5, 5), Orientacion.Vertical);
            tablero.AgregarNave(nave);
            
            List<Nave> naves = tablero.GetNavesEn(new Posicion(5, 5));

            Assert.AreEqual(nave, naves[0]);
        }

        [Test]
        public void testDeberiaTenerLaNaveConVidaSiNoSeLaAtaco()
        {
            Tablero tablero = new Tablero();
            tablero.AgregarNave(NaveFactory.CrearLancha(new Posicion(3, 3)));

            Assert.True(tablero.TieneNavesConVida());
        }
        [Test]
        public void testDeberiaNoTenerNaveConVidaSiLaAtaco()
        {
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, new Posicion(3, 3), Orientacion.Horizontal);
            nave.Direccion = (new Direccion(1, 0));
            tablero.AgregarNave(nave);
            DisparoComun disparo = ArmamentoFactory.CrearDisparoComun(new Tablero(), new Posicion(3, 3));
            disparo.TableroEnElQueEsta = (tablero);

            tablero.Impactar(disparo);
            tablero.Actualizar();

            Assert.False(tablero.TieneNavesConVida());
        }

        [Test]
        public void testDeberiaEstarVacioDespuesDeIngresarUnArmamentoYExplotarlo()
        {
            Tablero tablero = new Tablero();
            DisparoComun disparo = ArmamentoFactory.CrearDisparoComun(new Tablero(), new Posicion(3, 3));
            disparo.TableroEnElQueEsta = (tablero);

            tablero.Impactar(disparo);
            tablero.Actualizar();

            Assert.True(tablero.EstaVacio());
        }

        public void testNoDeberiaEstarVacioSiIngresoUnarmamentoPeroNoLoExploto()
        {
            Tablero tablero = new Tablero();
            DisparoComun disparo = ArmamentoFactory.CrearDisparoComun(new Tablero(), new Posicion(3, 3));
            disparo.TableroEnElQueEsta = tablero;

            tablero.Actualizar();

            Assert.False(tablero.EstaVacio());
        }


    }
}