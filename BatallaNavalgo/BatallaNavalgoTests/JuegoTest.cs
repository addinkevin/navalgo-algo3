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
        public static int CANTIDAD_DE_LANCHAS = 2;
        public static int CANTIDAD_DE_BUQUES = 1;
        public static int CANTIDAD_DE_DESTRUCTORES = 2;
        public static int CANTIDAD_DE_ROMPEHIELOS = 1;
        public static int CANTIDAD_DE_PORTAAVIONES = 1;

        /* Metodo auxiliar para probar el Juego. Se realizan disparos comunes sobre la posición (1,1).
         * Se realizan la cantidad de disparos especificadas en el argumento cantidad. Por cada disparo se descuenta 210 puntos
         * (200 puntos por el disparo y 10 por el paso de turno) */
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
            juego.Inicializar();

            Assert.False(juego.EstaTerminado());
        }

        [Test]
        public void testElJuegoNoDebeEstarGanadoAlCrearse()
        {
            Juego juego = new Juego();
            juego.Inicializar();

            Assert.False(juego.Ganado());
        }
        [Test, ExpectedException(typeof(JuegoJugadorSinPuntajeParaDisparoException))]
        public void testElJuegoDebeLanzarExcepcionSiIntentoHacerUnDisparoComunSinTenerElPuntajeNecesario()
        {
            Juego juego = new Juego();
            juego.Inicializar();

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
            juego.Inicializar();
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
            juego.Inicializar();
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
            juego.Inicializar();
            /* Dejo el puntaje del jugador a 130 =
             * PUNTAJE_INICIAL_JUGADOR - 47 * (COSTO_DISPARO_COMUN + COSTO_PASO_DE_TURNO) */
            HacerDisparosAlTableroParaBajarElPuntajeDelJugador(juego, 47);

            /* El juego no termino, porque el jugador tiene puntaje para poder al menos colocar una mina de bajo costo */
            Assert.False(juego.EstaTerminado());   
        }
        [Test]
        public void testVerificarLaCreacionDeLasNaves()
        {
            ObservadorParaPruebaDeIntegracion observador = new ObservadorParaPruebaDeIntegracion();
            Juego juego = new Juego();
            juego.AddObservador(observador);
            juego.Inicializar();

            /* Verifico que se cree la cantidad de naves que se tienen que crear */
            Assert.True(observador.NavesLancha.Count == JuegoTest.CANTIDAD_DE_LANCHAS);
            Assert.True(observador.NavesBuque.Count == JuegoTest.CANTIDAD_DE_BUQUES);
            Assert.True(observador.NavesDestructores.Count == JuegoTest.CANTIDAD_DE_DESTRUCTORES);
            Assert.True(observador.NavesPortaAviones.Count == JuegoTest.CANTIDAD_DE_PORTAAVIONES);
            Assert.True(observador.NavesRompeHielo.Count == JuegoTest.CANTIDAD_DE_ROMPEHIELOS);
        }

        [Test]
        public void testAtacarUnaNaveYVerificarQueSeRompa()
        {
            ObservadorParaPruebaDeIntegracion observador = new ObservadorParaPruebaDeIntegracion();
            Juego juego = new Juego();
            juego.AddObservador(observador);
            juego.Inicializar();

            Nave unaLancha = observador.NavesLancha[0];
            juego.EfectuarDisparoComun(unaLancha.GetPosiciones()[0]);
            juego.EfectuarDisparoComun(unaLancha.GetPosiciones()[1]);
            Assert.True(unaLancha.EstaDestruida());
        }

        [Test]
        public void testGeneralAtacarTodasLasNavesYVerificarQueSeGanoElJuego()
        {
            ObservadorParaPruebaDeIntegracion observador = new ObservadorParaPruebaDeIntegracion();
            Juego juego = new Juego();
            juego.AddObservador(observador);
            juego.Inicializar();

            // Rompo los rompeHielos
            foreach (Nave rompeHielo in observador.NavesRompeHielo)
            {
                int cantidadDePartes = rompeHielo.GetPosiciones().Count;
                for (int i = 0; i < cantidadDePartes; i++)
                {
                    juego.EfectuarDisparoComun(rompeHielo.GetPosiciones()[i]);
                    juego.EfectuarDisparoComun(rompeHielo.GetPosiciones()[i]);
                }
            }

            // Rompo los buques.
            foreach (Buque buque in observador.NavesBuque)
            {
                juego.EfectuarDisparoComun(buque.GetPosiciones()[0]);
            }

            List<Nave> listaNaves = new List<Nave>();
            listaNaves.AddRange(observador.NavesDestructores);
            listaNaves.AddRange(observador.NavesLancha);
            listaNaves.AddRange(observador.NavesPortaAviones);

            // Rompo el resto de las naves.
            foreach (Nave nave in listaNaves)
            {
                int cantidadDePartes = nave.GetPosiciones().Count();
                for (int i = 0; i < cantidadDePartes; i++)
                {
                    juego.EfectuarDisparoComun(nave.GetPosiciones()[i]);
                }
            }

            Assert.True(juego.Ganado());

        }
        
    }
}
