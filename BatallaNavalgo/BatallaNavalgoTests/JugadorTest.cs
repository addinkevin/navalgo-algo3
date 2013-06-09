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
            Tablero tablero = new Tablero();
            Jugador jugador = new Jugador(tablero);

            Assert.True(jugador.GetPuntos().Equals(10000));
        }

        [Test]
        public void testAlPasarUnTurnoDeberiaTener10PuntosMenos()
        {
            Tablero tablero = new Tablero();
            Jugador jugador = new Jugador(tablero);
            jugador.DescontarPuntosPorPasoDeTurno();

            Assert.True(jugador.GetPuntos().Equals(9990));
        }

        [Test]
        public void testAlDispararUnDisparoComunSeTendrianQueDescontar200Puntos()
        {
            Tablero tablero = new Tablero();
            Jugador jugador = new Jugador(tablero);
            jugador.Disparar(ArmamentoFactory.CrearDisparoComun(new Posicion(3, 3)));

            Assert.True(jugador.GetPuntos().Equals(9800));
        }

        [Test]
        public void testAlDispararUnaMinaPuntualSeTendrianQueDescontar50Puntos()
        {
            Tablero tablero = new Tablero();
            Jugador jugador = new Jugador(tablero);
            jugador.Disparar(ArmamentoFactory.CrearMinaPuntual(new Posicion(3, 3)));

            Assert.True(jugador.GetPuntos().Equals(9950));
        }

        [Test]
        public void testAlDispararUnaMinaDobleSeTendrianQueDescontar100Puntos()
        {
            Tablero tablero = new Tablero();
            Jugador jugador = new Jugador(tablero);
            jugador.Disparar(ArmamentoFactory.CrearMinaDoble(new Posicion(3, 3)));

            Assert.True(jugador.GetPuntos().Equals(9900));
        }

        [Test]
        public void testAlDispararUnaMinaTripleSeTendrianQueDescontar125Puntos()
        {
            Tablero tablero = new Tablero();
            Jugador jugador = new Jugador(tablero);
            jugador.Disparar(ArmamentoFactory.CrearMinaTriple(new Posicion(3, 3)));

            Assert.True(jugador.GetPuntos().Equals(9875));
        }

        [Test]
        public void testAlDispararUnaMinaPorContactoSeTendrianQueDescontar150Puntos()
        {
            Tablero tablero = new Tablero();
            Jugador jugador = new Jugador(tablero);
            jugador.Disparar(ArmamentoFactory.CrearMinaPorContacto(new Posicion(3, 3)));

            Assert.True(jugador.GetPuntos().Equals(9850));
        }
    }
}