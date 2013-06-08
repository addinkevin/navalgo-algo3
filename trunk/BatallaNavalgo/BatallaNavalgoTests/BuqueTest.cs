using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using NUnit.Framework;

namespace BatallaNavalgoTests
{
    [TestFixture]
    class BuqueTest
    {
        [Test]
        public void testDeberiaNoEstarDestruidaEnElMomentoDeLaCreacion()
        {
            Buque buque = new Buque(new Posicion(3, 3), Nave.VERTICAL);

            Assert.False(buque.EstaDestruida());
        }

        [Test]
        public void testDeberiaDestruirElBuqueAlRecibirUnDisparoComun()
        {
            Buque buque = new Buque(new Posicion(3, 3), Nave.VERTICAL);

            buque.RecibirAtaque(new DisparoComun(new Posicion(3, 3)));

            Assert.True(buque.EstaDestruida());
        }
        [Test]
        public void testDeberiaDestruirElBuqueAlRecibirUnaMina()
        {
            Armamento mina = ArmamentoFactory.CrearMinaPorContacto(new Posicion(3, 3));
            Buque buque = new Buque(new Posicion(3, 3), Nave.VERTICAL);

            buque.RecibirAtaque((Mina)mina);

            Assert.True(buque.EstaDestruida());
        }
    }
}
