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

            Assert.True(jugador.Puntos.Equals(Jugador.PUNTAJE_INICIAL_JUGADOR));
        }

        [Test]
        public void testAlPasarUnTurnoDeberiaTenerMenosPuntosSegunElCostoDelPasoDeTurno()
        {
            Jugador jugador = new Jugador();
            jugador.DescontarPuntosPorPasoDeTurno();

            Assert.True(jugador.Puntos.Equals(Jugador.PUNTAJE_INICIAL_JUGADOR - Jugador.PUNTAJE_DESCONTADO_POR_TURNO));
        }

        [Test]
        public void testAlDispararUnDisparoComunSeTendriaQueDescontarElCostoDeEste()
        {
            Jugador jugador = new Jugador();
            int costoDisparo = 500;
            Armamento armamento = new DisparoComun(new Tablero(), new Posicion(1, 1), costoDisparo);
            jugador.DescontarPuntosPorDisparar(armamento);

            Assert.True(jugador.Puntos.Equals(Jugador.PUNTAJE_INICIAL_JUGADOR - costoDisparo));
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

        [Test]
        public void testVerificarSiElJugadorPuedeRealizarUnDisparoConUnCostoMenorASuPuntaje()
        {
            Jugador jugador = new Jugador();

            Assert.True(jugador.TienePuntosParaJugar(100));
        }
        [Test]
        public void testVerificarQueElJugadorNoPuedeRealizarUnDisparoConUnCostoIgualASuPuntajeDebidoAlCostoPorPaseDeTurno()
        {
            Jugador jugador = new Jugador();
            
            /* Necesita puntos para efectuar el disparo y para el paso del turno */
            Assert.False(jugador.TienePuntosParaJugar(Jugador.PUNTAJE_INICIAL_JUGADOR));
        }
    }
}