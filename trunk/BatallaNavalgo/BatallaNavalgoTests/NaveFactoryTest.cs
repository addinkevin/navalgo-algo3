using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using NUnit.Framework;

namespace BatallaNavalgoTests
{
    [TestFixture]
    class NaveFactoryTest
    {
        [Test]
        public void testCrearLanchaDevuelveNaveConDosCasillas()
        {
            Posicion posicion = new Posicion(5,5);
            int orientacion = 0;            
            int cantidadDePartes;

            Nave lancha = NaveFactory.CrearLancha(posicion, orientacion);
            cantidadDePartes = lancha.GetPosiciones().Count;
            
            Assert.True(cantidadDePartes==2);          
        }

        [Test]
        public void testCrearDestructorDevuelveNaveConTresCasillas()
        {
            Posicion posicion = new Posicion(5, 5);
            int orientacion = 0;
            int cantidadDePartes;

            Destructor destructor = NaveFactory.CrearDestructor(posicion, orientacion);
            cantidadDePartes = destructor.GetPosiciones().Count;

            Assert.True(cantidadDePartes == 3);
        }

        [Test]
        public void testCrearBuqueDevuelveNaveConCuatroCasillas()
        {
            Posicion posicion = new Posicion(5, 5);
            int orientacion = 0;
            int cantidadDePartes;

            Buque buque = NaveFactory.CrearBuque(posicion, orientacion);
            cantidadDePartes = buque.GetPosiciones().Count;

            Assert.True(cantidadDePartes == 4);
        }

        [Test]
        public void testCrearPortaAvionesDevuelveNaveConCincoCasillas()
        {
            Posicion posicion = new Posicion(5, 5);
            int orientacion = 0;
            int cantidadDePartes;

            Nave portaAviones = NaveFactory.CrearPortaAviones(posicion, orientacion);
            cantidadDePartes = portaAviones.GetPosiciones().Count;

            Assert.True(cantidadDePartes == 5);
        }

        [Test]
        public void testCrearRompeHielosDevuelveNaveConTresCasillas()
        {
            Posicion posicion = new Posicion(5, 5);
            int orientacion = 0;
            int cantidadDePartes;

            Nave rompehielos = NaveFactory.CrearRompeHielos(posicion, orientacion);
            cantidadDePartes = rompehielos.GetPosiciones().Count;

            Assert.True(cantidadDePartes == 3);
        }      


    }
}
