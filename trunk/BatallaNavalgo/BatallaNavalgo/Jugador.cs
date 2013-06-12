using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Jugador
    {
        public static int PUNTAJE_INICIAL_JUGADOR = 10000;
        public static int PUNTAJE_DESCONTADO_POR_TURNO = 10;

        private int puntos;
        private Tablero tablero;

        /* Constructor
         * puntos: seran los puntos con los que cuente el Jugador inicialmente.
         * tablero: sera el tablero asociado que tendra el Jugador.
         */
        public Jugador(Tablero tablero)
        {
            this.puntos = PUNTAJE_INICIAL_JUGADOR;
            this.tablero = tablero;
        }
        //---------------------------------------------------------------------

        public int Puntos
        {
            get {return this.puntos;}            
        }

        public void DescontarPuntosPorPasoDeTurno()
        {
            puntos -= PUNTAJE_DESCONTADO_POR_TURNO;
        }

        public void Disparar(Armamento armamento)
        {
            tablero.Impactar(armamento);
            puntos -= (armamento.GetCosto());
        }
    }
}
