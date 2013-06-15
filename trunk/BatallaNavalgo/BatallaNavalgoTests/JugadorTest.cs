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
            jugador.DescontarPuntosPorDisparar(ArmamentoFactory.CrearDisparoComun(new Tablero(), new Posicion(3, 3)));

            Assert.True(jugador.Puntos.Equals(9800));
        }

        [Test]
        public void testAlDispararUnaMinaPuntualSeTendrianQueDescontar50Puntos()
        {
            Jugador jugador = new Jugador();
            jugador.DescontarPuntosPorDisparar(ArmamentoFactory.CrearMinaPuntual(new Tablero(), new Posicion(3, 3)));

            Assert.True(jugador.Puntos.Equals(9950));
        }

        [Test]
        public void testAlDispararUnaMinaDobleSeTendrianQueDescontar100Puntos()
        {
            Jugador jugador = new Jugador();
            jugador.DescontarPuntosPorDisparar(ArmamentoFactory.CrearMinaDoble(new Tablero(), new Posicion(3, 3)));

            Assert.True(jugador.Puntos.Equals(9900));
        }

        [Test]
        public void testAlDispararUnaMinaTripleSeTendrianQueDescontar125Puntos()
        {
            Jugador jugador = new Jugador();
            jugador.DescontarPuntosPorDisparar(ArmamentoFactory.CrearMinaTriple(new Tablero(), new Posicion(3, 3)));

            Assert.True(jugador.Puntos.Equals(9875));
        }

        [Test]
        public void testAlDispararUnaMinaPorContactoSeTendrianQueDescontar150Puntos()
        {
            Jugador jugador = new Jugador();
            jugador.DescontarPuntosPorDisparar(ArmamentoFactory.CrearMinaPorContacto(new Tablero(), new Posicion(3, 3)));

            Assert.True(jugador.Puntos.Equals(9850));
        }

        [Test, ExpectedException(typeof(JugadorPuntajeInsuficienteException))]
        public void testDeberiaLanzarErrorSiIntentoHacerDisparosSinPuntaje()
        {
            DisparoComun disparo = new DisparoComun(new Tablero(), new Posicion(1, 1), Jugador.PUNTAJE_INICIAL_JUGADOR/ 10);
            Jugador jugador = new Jugador();
            // Hago los 10 disparos posibles que puede hacer el jugador.
            for (int i = 0; i < 10; i++)
            {
                jugador.DescontarPuntosPorDisparar(disparo);
            }

            // Tiene que lanzar excepcion.
            jugador.DescontarPuntosPorDisparar(disparo);
        }

        [Test, ExpectedException(typeof(JugadorPuntajeInsuficienteException))]
        public void testDeberiaLanzarErrorSiIntentoDescontarPuntosPorAvanzarElTurnoMasVecesDeLoPosible()
        {
            Jugador jugador = new Jugador();
            for (int i = 0; i < Jugador.PUNTAJE_INICIAL_JUGADOR/ Jugador.PUNTAJE_DESCONTADO_POR_TURNO; i++)
            {
                jugador.DescontarPuntosPorPasoDeTurno();
            }

            // Tiene que lanzar excepcion.
            jugador.DescontarPuntosPorPasoDeTurno();
        }

        [Test, ExpectedException(typeof(JugadorPuntajeInsuficienteException))]
        public void testDebeLanzarErrorSiIntentoHacerUnDisparoSinLaCantidadDePuntosParaHacerlo()
        {
            Jugador jugador = new Jugador();
            DisparoComun disparo = new DisparoComun(new Tablero(), new Posicion(1, 1), Jugador.PUNTAJE_INICIAL_JUGADOR + 1);

            // Tiene que lanzar excepcion.
            jugador.DescontarPuntosPorDisparar(disparo);

        }
    }
}