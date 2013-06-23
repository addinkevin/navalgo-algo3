using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Jugador
    {
        public static int PUNTAJE_INICIAL_JUGADOR = 10000;
//        public static int PUNTAJE_DESCONTADO_POR_TURNO = 10;
        public static int PUNTAJE_DESCONTADO_POR_TURNO = 1000;
        private Boolean jugando;

        private int puntos;

        /* Constructor
         * puntos: seran los puntos con los que cuente el Jugador inicialmente.
         */
        public Jugador()
        {
            this.puntos = PUNTAJE_INICIAL_JUGADOR;
            jugando = true;
        }
		
        //Metodos de la clase Jugador

        public int Puntos
        {
            get {return this.puntos;}            
        }

        public void DescontarPuntosPorPasoDeTurno()
        {
            if (puntos < PUNTAJE_DESCONTADO_POR_TURNO)
            {
                jugando = false;
                throw new BatallaNavalgoExcepciones.JugadorPuntajeInsuficienteException();
            }                

            puntos -= PUNTAJE_DESCONTADO_POR_TURNO;
        }

        public void DescontarPuntosPorDisparar(Armamento armamento)
        {
            if (this.puntos < armamento.Costo) {
                jugando = false;
                throw new BatallaNavalgoExcepciones.JugadorPuntajeInsuficienteException();
            }
            puntos -= (armamento.Costo);
        }

        /* Verifica si tiene puntaje necesario para disparar un armamento con costo "costoDeDisparo"
         * y si tiene el puntaje necesario para el paso de turno */
        public bool TienePuntosParaJugar(int costoDeDisparo)
        {
            return (this.puntos >= costoDeDisparo + Jugador.PUNTAJE_DESCONTADO_POR_TURNO);
        }

        public Boolean Jugando 
        {
            get { return this.jugando;}
            set { jugando = value; }
        }
    }
}
