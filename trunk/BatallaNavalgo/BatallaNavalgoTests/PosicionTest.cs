﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using NUnit.Framework;


namespace BatallaNavalgoTests
{
    [TestFixture]
    class PosicionTest
    {
        [Test]
        public void testCrearUnaPosicionYObtenerFilaYColumna()
        {
            Posicion posicion = new Posicion(3, 6);
            Assert.AreEqual(3, posicion.GetFila());
            Assert.AreEqual(6, posicion.GetColumna());
        }
    }
}