using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Batalla_Navalgo
{
    class Posicion
    {
        private int fila, columna;

        public Posicion(int fila, int columna)
        {
            this.fila = fila;
            this.columna = columna;
        }
        //-----------------------------------------------------------

        public int GetFila() 
        {
            return this.fila;
        }
        //-----------------------------------------------------------

        public int GetColumna()
        {
            return this.columna;
        }
        //-----------------------------------------------------------

        public void SetFila(int nuevaFila)
        {
            this.fila = nuevaFila;
        }
        //-----------------------------------------------------------

        public void SetColumna(int nuevaColumna)
        {
            this.columna = nuevaColumna;
        }
        //-----------------------------------------------------------

        
    }
}
