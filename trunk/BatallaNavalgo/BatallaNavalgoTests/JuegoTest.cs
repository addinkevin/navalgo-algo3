using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using NUnit.Framework;

namespace BatallaNavalgoTests
{
    [TestFixture]
    class JuegoTest
    {
        [Test]
        public void testElJuegoNoDebeEstarTerminadoAlCrearse()
        {
            Juego juego = new Juego();

            Assert.False(juego.EstaTerminado());
        }

    }
}
