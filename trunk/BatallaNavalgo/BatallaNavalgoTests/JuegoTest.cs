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
    class JuegoTest
    {
        /* Metodo auxiliar para probar el Juego. Se realizan disparos comunes sobre la posición (1,1).
         * Se realizan la cantidad de disparos especificadas en el argumento cantidad. Por cada disparo se descuenta 210 puntos */
        private void HacerDisparosAlTableroParaBajarElPuntajeDelJugador(Juego juego, int cantidad)
        {
            Posicion posicion = new Posicion(1,1);
            for (int i = 0; i < cantidad; i++)
            {
                juego.EfectuarDisparoComun(posicion);
            }
        }

        [Test]
        public void testElJuegoNoDebeEstarTerminadoAlCrearse()
        {
            Juego juego = new Juego();

            Assert.False(juego.EstaTerminado());
        }

        [Test, ExpectedException(typeof(JuegoJugadorSinPuntajeParaDisparoException))]
        public void testElJuegoDebeLanzarExcepcionSiIntentoHacerUnDisparoComunSinTenerElPuntajeNecesario()
        {
            Juego juego = new Juego();
            /* Dejo el puntaje del jugador a 130 =
             * PUNTAJE_INICIAL_JUGADOR - 47 * (COSTO_DISPARO_COMUN + COSTO_PASO_DE_TURNO) */
            HacerDisparosAlTableroParaBajarElPuntajeDelJugador(juego, 47);
            
            // Debe lanzar excepcion.
            juego.EfectuarDisparoComun(new Posicion(1, 1));
            
        }

        [Test, ExpectedException(typeof(JuegoTerminadoException))]
        public void testElJuegoDebeLanzarExcepcionSiNoTengoMasPosibilidadDeHacerDisparoPorNoTenerPuntos()
        {
            Juego juego = new Juego();
            /* Dejo el puntaje del jugador a 130 =
             * PUNTAJE_INICIAL_JUGADOR - 47 * (COSTO_DISPARO_COMUN + COSTO_PASO_DE_TURNO) */
            HacerDisparosAlTableroParaBajarElPuntajeDelJugador(juego, 47);
            /* Dejo al jugador con 20 puntos, de forma de que no tenga mas chances de poder disparar */
            juego.ColocarMinaDoble(new Posicion(1, 1));

            // Debe lanzar excepcion.
            juego.EfectuarDisparoComun(new Posicion(1, 1));
        }

        [Test]
        public void testElJuegoDebeTerminarSiNoTengoMasPosibilidadDeHacerDisparoPorNoTenerPuntos()
        {
            Juego juego = new Juego();
            /* Dejo el puntaje del jugador a 130 =
             * PUNTAJE_INICIAL_JUGADOR - 47 * (COSTO_DISPARO_COMUN + COSTO_PASO_DE_TURNO) */
            HacerDisparosAlTableroParaBajarElPuntajeDelJugador(juego, 47);
            /* Dejo al jugador con 20 puntos, de forma de que no tenga mas chances de poder disparar */
            juego.ColocarMinaDoble(new Posicion(1, 1));

            Assert.True(juego.EstaTerminado());
        }

        [Test]
        public void testElJuegoNoDebeTerminarSiAunPuedoRealizarUnDisparoDeBajoCosto()
        {
            Juego juego = new Juego();
            /* Dejo el puntaje del jugador a 130 =
             * PUNTAJE_INICIAL_JUGADOR - 47 * (COSTO_DISPARO_COMUN + COSTO_PASO_DE_TURNO) */
            HacerDisparosAlTableroParaBajarElPuntajeDelJugador(juego, 47);

            /* El juego no termino, porque el jugador tiene puntaje para poder al menos colocar una mina de bajo costo */
            Assert.False(juego.EstaTerminado());
            
        }
    }
}
