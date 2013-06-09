using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Jugador
    {
        private int puntos;
        private Tablero tablero;

        /* Constructor
         * puntos: seran los puntos con los que cuente el Jugador inicialmente.
         * tablero: sera el tablero asociado que tendra el Jugador.
         */
        public Jugador(Tablero tablero)
        {
            this.puntos = 10000;
            this.tablero = tablero;
        }
        //---------------------------------------------------------------------

        public int GetPuntos()
        {
            return this.puntos;
        }

        public void DescontarPuntosPorPasoDeTurno()
        {
            puntos -= 10;
        }

        public void Disparar(Armamento armamento)
        {
            tablero.Impactar(armamento);
            puntos -= (armamento.GetCosto());
        }
    }
}
