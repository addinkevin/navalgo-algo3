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
            Buque buque = new Buque(new Posicion(3, 3), Orientacion.Vertical, Direccion.Oeste);

            Assert.False(buque.EstaDestruida());
        }

        [Test]
        public void testDeberiaDestruirElBuqueAlRecibirUnDisparoComun()
        {
            Posicion posicion = new Posicion(3, 3);
            Buque buque = new Buque(posicion, Orientacion.Vertical,Direccion.Sur);

            buque.RecibirAtaque(ArmamentoFactory.CrearDisparoComun(new Tablero(), posicion), posicion);

            Assert.True(buque.EstaDestruida());
        }
        [Test]
        public void testDeberiaDestruirElBuqueAlRecibirUnaMina()
        {
            Posicion posicion = new Posicion(3, 3);
            Mina mina = ArmamentoFactory.CrearMinaPorContacto(new Tablero(), posicion);
            Buque buque = new Buque(posicion, Orientacion.Vertical, Direccion.Norte);

            buque.RecibirAtaque(mina,posicion);

            Assert.True(buque.EstaDestruida());
        }
    }
}
