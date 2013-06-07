using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Posicion
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

        public Boolean EstaDentroDe(int fila1, int columna1, int fila2, int columna2)
        {
            Boolean dentroDeFilas = (this.fila >= fila1 && this.fila <= fila2);
            Boolean dentroDeColumnas = (this.columna >= columna1 && this.columna <= columna2);
            return (dentroDeFilas && dentroDeColumnas);
        }
    }
}
