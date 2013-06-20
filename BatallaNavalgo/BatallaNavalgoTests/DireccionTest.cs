using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BatallaNavalgo;

namespace BatallaNavalgoTests
{
    [TestFixture]
    class DireccionTest
    {
        [Test]
        public void testObtenerNuevaPosicionAlCrearUnaDireccionNorte()
        {
            Posicion posicion = new Posicion(3, 3);
            // Direccion que resta una fila, simula una direccion Norte.
            Direccion direccion = Direccion.Este;

            Posicion nuevaPosicion = direccion.GetNuevaPosicion(posicion);

            Assert.True(nuevaPosicion.EsIgualA(new Posicion(3, 4)));
        }

        [Test]
        public void testObtenerNuevaPosicionInvirtiendoUnaDireccion()
        {
            Posicion posicion = new Posicion(3, 3);
            Direccion direccion = Direccion.Norte;

            direccion = direccion.Invertir();
            Posicion nuevaPosicion = direccion.GetNuevaPosicion(posicion);

            Assert.True(nuevaPosicion.EsIgualA(new Posicion(4, 3)));
        }
    }
}
