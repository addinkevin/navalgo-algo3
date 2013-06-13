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
            Assert.False(mina.Explotado);            
        }

        [Test]
        public void testNoDeberiaExplotarAlActualizarSiNoHayNavesAlAlrededor()
        {
            MinaPorContacto mina = new MinaPorContacto();
            mina.TableroEnElQueEsta = (new Tablero());
            mina.Actualizar();

            Assert.False(mina.Explotado);
        }

        [Test]
        public void testDeberiaExplotarSiSuPosicionCoincideConLaDeUnaNave()
        {
            MinaPorContacto mina = new MinaPorContacto();
            Posicion posicion = new Posicion(5,5);
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, posicion, Nave.VERTICAL);
            tablero.AgregarNave(nave);
            mina.Posicion = posicion;
            mina.TableroEnElQueEsta = (tablero);

            mina.Actualizar();
            Assert.True(mina.Explotado);
        }

        [Test]
        public void testSiColisionaConVariasNavesTodasLasColisionadasRecibenImpacto()
        {
            /*En este caso las naves son puntuales para comprobar su destruccion total*/
            MinaPorContacto mina = new MinaPorContacto();
            Posicion posicion = new Posicion(5, 5);
            Tablero tablero = new Tablero();
            Nave nave1 = new Nave(1, 1, posicion, Nave.VERTICAL);
            Nave nave2 = new Nave(1, 1, posicion, Nave.HORIZONTAL);            
            tablero.AgregarNave(nave1);
            tablero.AgregarNave(nave2);
            mina.Posicion = posicion;
            mina.TableroEnElQueEsta = tablero;

            mina.Actualizar();
            Assert.True(nave1.EstaDestruida() && nave2.EstaDestruida());
        }

        [Test]
        public void testSiHayNaveEnPosicionVecinaNoExplota()
        {
            /*En este caso las naves son puntuales para comprobar su destruccion total*/
            MinaPorContacto mina = new MinaPorContacto();
            Posicion posicionMina = new Posicion(5, 5);
            Posicion posicionNave = new Posicion(6, 5);
            Tablero tablero = new Tablero();
            Nave nave1 = new Nave(1, 1, posicionNave, Nave.HORIZONTAL);            
            tablero.AgregarNave(nave1);
            mina.Posicion = posicionMina;
            mina.TableroEnElQueEsta = tablero;

            mina.Actualizar();
            Assert.False(mina.Explotado);
        }

        [Test]
        public void testSiDespuesDeExplotadaLaMinaUnaNaveVuelveAPasarPorEncimaNoExplotaDeNuevo()
        {
            MinaPorContacto mina = new MinaPorContacto();
            Posicion posicion = new Posicion(5, 5);
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, posicion, Nave.VERTICAL);
            Nave nave2 = new Nave(5, 5, posicion, Nave.VERTICAL);
            tablero.AgregarNave(nave);
            mina.Posicion = posicion;
            mina.TableroEnElQueEsta = tablero;
            mina.Actualizar();

            tablero.AgregarNave(nave2);
            mina.Actualizar();

            Assert.True(nave.EstaDestruida() && !nave2.EstaDestruida());
        }


    }
}
