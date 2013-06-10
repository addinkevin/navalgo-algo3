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
            Posicion posicion = new Posicion(3, 3);
            Buque buque = new Buque(posicion, Nave.VERTICAL);

            buque.RecibirAtaque(ArmamentoFactory.CrearDisparoComun(posicion), posicion);

            Assert.True(buque.EstaDestruida());
        }
        [Test]
        public void testDeberiaDestruirElBuqueAlRecibirUnaMina()
        {
            Posicion posicion = new Posicion(3, 3);
            Mina mina = ArmamentoFactory.CrearMinaPorContacto(posicion);
            Buque buque = new Buque(posicion, Nave.VERTICAL);

            buque.RecibirAtaque(mina,posicion);

            Assert.True(buque.EstaDestruida());
        }
    }
}
