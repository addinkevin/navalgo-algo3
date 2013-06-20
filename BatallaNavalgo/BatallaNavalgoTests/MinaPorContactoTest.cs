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
            Tablero tablero = new Tablero();
            Posicion posicion = new Posicion(1, 1);
            int costoRandom = 100;
            
            MinaPorContacto mina = new MinaPorContacto(tablero, posicion, costoRandom);
            Assert.False(mina.Explotado);            
        }

        [Test]
        public void testNoDeberiaExplotarAlActualizarSiNoHayNavesAlAlrededor()
        {
            Tablero tablero = new Tablero();
            Posicion posicion = new Posicion(1, 1);
            int costoRandom = 100;
            MinaPorContacto mina = new MinaPorContacto(tablero, posicion,costoRandom);

            mina.Actualizar();

            Assert.False(mina.Explotado);
        }

        [Test]
        public void testDeberiaExplotarSiSuPosicionCoincideConLaDeUnaNave()
        {
            Tablero tablero = new Tablero();
            Posicion posicionNave = new Posicion(5, 5);
            Nave nave = new Nave(1, 1, posicionNave, Orientacion.Vertical);
            tablero.AgregarNave(nave);
            int costoRandom = 100;
            MinaPorContacto mina = new MinaPorContacto(tablero, posicionNave, costoRandom);
          
            mina.Actualizar();

            Assert.True(mina.Explotado);
        }

        [Test]
        public void testSiColisionaConVariasNavesTodasLasColisionadasRecibenImpacto()
        {
            /*En este caso las naves son puntuales para comprobar su destruccion total*/
            Tablero tablero = new Tablero();
            Posicion posicion = new Posicion(5, 5);
            Nave nave1 = new Nave(1, 1, posicion, Orientacion.Vertical);
            Nave nave2 = new Nave(1, 1, posicion, Orientacion.Horizontal);
            tablero.AgregarNave(nave1);
            tablero.AgregarNave(nave2);
            int costoRandom = 100;
            MinaPorContacto mina = new MinaPorContacto(tablero, posicion, costoRandom);

            mina.Actualizar();

            Assert.True(nave1.EstaDestruida() && nave2.EstaDestruida());
        }

        [Test]
        public void testSiHayNaveEnPosicionVecinaNoExplota()
        {
            /*En este caso las naves son puntuales para comprobar que no se destruye*/
            Tablero tablero = new Tablero();
            Posicion posicionNave = new Posicion(6, 5);
            Nave nave1 = new Nave(1, 1, posicionNave, Orientacion.Horizontal);            
            tablero.AgregarNave(nave1);
            Posicion posicionMina = new Posicion(5, 5);
            int costoRandom = 100;
            MinaPorContacto mina = new MinaPorContacto(tablero, posicionMina, costoRandom);
            
            mina.Actualizar();

            Assert.False(mina.Explotado);
        }

        [Test]
        public void testSiDespuesDeExplotadaLaMinaUnaNaveVuelveAPasarPorEncimaNoExplotaDeNuevo()
        {
            Posicion posicionNave = new Posicion(5, 5);
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, posicionNave, Orientacion.Vertical);
            Nave nave2 = new Nave(5, 5, posicionNave, Orientacion.Vertical);
            tablero.AgregarNave(nave);
            int costoRandom = 100;
            MinaPorContacto mina = new MinaPorContacto(tablero, posicionNave, costoRandom);

            mina.Actualizar();
            tablero.AgregarNave(nave2);
            mina.Actualizar();

            Assert.True(nave.EstaDestruida() && !nave2.EstaDestruida());
        }


    }
}
