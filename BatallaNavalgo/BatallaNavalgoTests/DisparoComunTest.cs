using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using NUnit.Framework;

namespace BatallaNavalgoTests
{
    [TestFixture]
    class DisparoComunTest
    {
        [Test]
        public void testDeberiaNoEstarExplotadoAlCrearlo()
        {
            DisparoComun disparo = new DisparoComun(new Tablero(), new Posicion(1,1),100);

            Assert.False(disparo.Explotado);
        }
        /*-------------------------------------------*/
        [Test]
        public void testDeberiaEstarExplotadoCuandoLoActualizo()
        {
            DisparoComun disparo = new DisparoComun(new Tablero(), new Posicion(3,3), 100);

            disparo.Actualizar();

            Assert.True(disparo.Explotado);
        }
        /*-------------------------------------------*/

        [Test]
        public void testDeberiaAtacarALaNaveSoloUnaVez()
        {
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 2, new Posicion(1, 1), Nave.VERTICAL);
            tablero.AgregarNave(nave);
            DisparoComun disparo = new DisparoComun(tablero, new Posicion(1,1), 100);

            disparo.Actualizar();
            disparo.Actualizar();

            // Es una nave de una parte con resistencia dos. Solo recibio un disparo. No debe estar destruida.
            Assert.False(nave.EstaDestruida());
        }
        /*-------------------------------------------*/

        [Test]
        public void testSiHayVariasNavesEnUnaPosicionAlExplotarLasAtacaATodas()
        {
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, new Posicion(1, 1), Nave.VERTICAL);
            Nave nave2 = new Nave(1, 1, new Posicion(1, 1), Nave.VERTICAL);
            tablero.AgregarNave(nave);
            tablero.AgregarNave(nave2);
            DisparoComun disparo = new DisparoComun(tablero, new Posicion(1,1), 100);

            disparo.Actualizar();
            disparo.Actualizar();
            
            Assert.True(nave.EstaDestruida() && nave2.EstaDestruida());
        }
        /*-------------------------------------------*/

        [Test]
        public void testSiHayUnaNaveEnUnaPosicionVecinaNoLaAtaca()
        {
            Tablero tablero = new Tablero();
            Nave nave = new Nave(1, 1, new Posicion(1, 1), Nave.VERTICAL);
            
            tablero.AgregarNave(nave);            
            DisparoComun disparo = new DisparoComun(tablero, new Posicion(1,2), 100);

            disparo.Actualizar();
            disparo.Actualizar();

            Assert.False(nave.EstaDestruida());
        }



    }
}
