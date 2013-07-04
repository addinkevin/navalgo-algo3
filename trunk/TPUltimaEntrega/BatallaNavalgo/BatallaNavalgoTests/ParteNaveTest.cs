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
    class ParteNaveTest
    {
        [Test]
        public void testDeberiaEstarNoDestruidaAlCrearlaInicialmente()
        {
            ParteNave parte = new ParteNave(1, new Posicion(1, 1));
        }

        [Test]
        public void testDeberiaDestruirUnaParteDeResistenciaUnoSiLaAtaco()
        {
            ParteNave parte = new ParteNave(1, new Posicion(1, 1));
            parte.RecibirAtaque();

            Assert.True(parte.EstaDestruida());

        }

        [Test]
        public void testNoDeberiaDestruirLaParteDeResistenciaDosSiRecibeUnSoloDisparo()
        {
            ParteNave parte = new ParteNave(2, new Posicion(1, 1));
            parte.RecibirAtaque();

            Assert.False(parte.EstaDestruida());

        }
        
    }
}
