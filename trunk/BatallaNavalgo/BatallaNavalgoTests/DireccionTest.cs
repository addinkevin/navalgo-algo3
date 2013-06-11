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
            Direccion direccion = new Direccion(-1, 0);

            Posicion nuevaPosicion = direccion.GetNuevaPosicion(posicion);

            Assert.True(nuevaPosicion.EsIgualA(new Posicion(2, 3)));
        }
        [Test]
        public void testObtenerNuevaPosicionDadaUnaDireccionCualquiera()
        {
            Posicion posicion = new Posicion(3, 3);
            Direccion direccion = new Direccion(3, -3);

            Posicion nuevaPosicion = direccion.GetNuevaPosicion(posicion);

            Assert.True(nuevaPosicion.EsIgualA(new Posicion(6, 0)));
        }

        [Test]
        public void testObtenerNuevaPosicionInvirtiendoUnaDireccionCualquiera()
        {
            Posicion posicion = new Posicion(3, 3);
            Direccion direccion = new Direccion(2, -2);

            direccion.Invertir();
            Posicion nuevaPosicion = direccion.GetNuevaPosicion(posicion);

            Assert.True(nuevaPosicion.EsIgualA(new Posicion(1, 5)));

        }

        [Test]
        public void testEstandoEnLaPrimerFilaDelTableroEIntentandoIrAlNorteSeInvierteLaDireccion()
        {
            Posicion posicion = new Posicion(1, 5);
            Direccion direccion = new Direccion(-1, 0);            
            Direccion direccionDespuesDeChocar = new Direccion(1, 0);
            
            Posicion nuevaPosicion = direccion.GetNuevaPosicion(posicion);            
            
            Assert.True(direccion.EsigualA(direccionDespuesDeChocar));
        }

        [Test]
        public void testAlChocharEnFilaUnoYendoAlNorteInvierteLaDireccion()
        {
            Posicion posicion = new Posicion(1, 5);
            Direccion direccion = new Direccion(-1, 0);

            Posicion nuevaPosicion = direccion.GetNuevaPosicion(posicion);

            Assert.True(nuevaPosicion.EsIgualA(new Posicion(2, 5)));
        }

    }
}
