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
            MinaConRetardo mina = new MinaConRetardo(1, 1);

            Assert.False(mina.Explotado);
        }

        [Test]
        public void testDeberiaEstarExplotadaSiLaActualizoTantasVecesComoSuRetardo()
        {
            MinaConRetardo mina = new MinaConRetardo(1, 2);
            mina.SetPosicion(new Posicion(3, 3));
            mina.TableroEnElQueEsta =(new Tablero());

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
            MinaConRetardo mina = new MinaConRetardo(1, 1);
            Posicion posicionMina = new Posicion(3, 3);
            mina.SetPosicion(posicionMina);
            mina.TableroEnElQueEsta = (tablero);
            
            mina.Actualizar();

            Assert.True(nave.EstaDestruida());
        }
    }
}
