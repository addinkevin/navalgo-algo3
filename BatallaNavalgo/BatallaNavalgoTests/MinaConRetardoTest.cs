using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using NUnit.Framework;

namespace BatallaNavalgoTests
{
    [TestFixture]
    class MinaConRetardoTest
    {
        [Test]
        public void testDeberiaNoEstarExplotadaAlCrearla()
        {
            Tablero tablero = new Tablero();
            Posicion posicion = new Posicion(1,1);
            int costoRandom = 100;
            int radio = 1;
            int retardo = 1;

            MinaConRetardo mina = new MinaConRetardo(tablero, posicion, costoRandom, radio, retardo);

            Assert.False(mina.Explotado);
        }

        [Test]
        public void testDeberiaEstarExplotadaSiLaActualizoTantasVecesComoSuRetardo()
        {
            Tablero tablero = new Tablero();
            Posicion posicion = new Posicion(1, 1);
            int costoRandom = 100;
            int radio = 1;
            int retardo = 2;
            MinaConRetardo mina = new MinaConRetardo(tablero, posicion, costoRandom, radio, retardo);

            mina.Actualizar();
            mina.Actualizar();

            Assert.True(mina.Explotado);
        }

        [Test]
        public void testSiHayNaveEnSuRadioDeAlcanceDeberiaDañarla()
        {
            Posicion posicionNave = new Posicion(2, 3);
            Nave nave = new Nave(1, 1, posicionNave, Nave.HORIZONTAL);
            Tablero tablero = new Tablero();
            tablero.AgregarNave(nave);
            Posicion posicionMina = new Posicion(3, 3);
            int costoRandom = 100;
            int radio = 1;
            int retardo = 1;
            MinaConRetardo mina = new MinaConRetardo(tablero, posicionMina, costoRandom, radio, retardo);
            
            mina.Actualizar();

            Assert.True(nave.EstaDestruida());
        }
    }
}
