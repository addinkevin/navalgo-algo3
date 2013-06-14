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
    class JugadorTest
    {
        [Test]
        public void testAlCrearAlJugadorDeberiaTenerLaCantidadDePuntosOriginal()
        {
            Jugador jugador = new Jugador();

            Assert.True(jugador.Puntos.Equals(10000));
        }

        [Test]
        public void testAlPasarUnTurnoDeberiaTener10PuntosMenos()
        {
            Jugador jugador = new Jugador();
            jugador.DescontarPuntosPorPasoDeTurno();

            Assert.True(jugador.Puntos.Equals(9990));
        }

        [Test]
        public void testAlDispararUnDisparoComunSeTendrianQueDescontar200Puntos()
        {
            Jugador jugador = new Jugador();
            jugador.DescontarPuntosPorDisparar(ArmamentoFactory.CrearDisparoComun(new Posicion(3, 3)));

            Assert.True(jugador.Puntos.Equals(9800));
        }

        [Test]
        public void testAlDispararUnaMinaPuntualSeTendrianQueDescontar50Puntos()
        {
            Jugador jugador = new Jugador();
            jugador.DescontarPuntosPorDisparar(ArmamentoFactory.CrearMinaPuntual(new Posicion(3, 3)));

            Assert.True(jugador.Puntos.Equals(9950));
        }

        [Test]
        public void testAlDispararUnaMinaDobleSeTendrianQueDescontar100Puntos()
        {
            Jugador jugador = new Jugador();
            jugador.DescontarPuntosPorDisparar(ArmamentoFactory.CrearMinaDoble(new Posicion(3, 3)));

            Assert.True(jugador.Puntos.Equals(9900));
        }

        [Test]
        public void testAlDispararUnaMinaTripleSeTendrianQueDescontar125Puntos()
        {
            Jugador jugador = new Jugador();
            jugador.DescontarPuntosPorDisparar(ArmamentoFactory.CrearMinaTriple(new Posicion(3, 3)));

            Assert.True(jugador.Puntos.Equals(9875));
        }

        [Test]
        public void testAlDispararUnaMinaPorContactoSeTendrianQueDescontar150Puntos()
        {
            Jugador jugador = new Jugador();
            jugador.DescontarPuntosPorDisparar(ArmamentoFactory.CrearMinaPorContacto(new Posicion(3, 3)));

            Assert.True(jugador.Puntos.Equals(9850));
        }
    }
}