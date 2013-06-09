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

            Assert.False(mina.EstaExplotado());
        }
        [Test]
        public void testDeberiaEstarExplotadaSiLaActualizoTantasVecesComoSuRetardo()
        {
            MinaConRetardo mina = new MinaConRetardo(1, 2);

            mina.Actualizar();
            mina.Actualizar();

            Assert.True(mina.EstaExplotado());
        }
    }
}
