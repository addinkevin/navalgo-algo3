using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Posicion : IEquatable<Posicion>
    {
        private int fila, columna;

        public Posicion(int fila, int columna)
        {
            this.fila = fila;
            this.columna = columna;
        }
        //-----------------------------------------------------------
        public int Fila 
        {
            get { return fila; }
        }
        //-----------------------------------------------------------
        public int Columna
        {
            get { return columna; }
        }               
        //-----------------------------------------------------------

        public Boolean EstaDentroDe(Posicion posicion1, Posicion posicion2)
        {
            Boolean dentroDeFilas = (this.fila >= posicion1.Fila && this.fila <= posicion2.Fila);
            Boolean dentroDeColumnas = (this.columna >= posicion1.Columna && this.columna <= posicion2.Columna);
            return (dentroDeFilas && dentroDeColumnas);
        }

        public Boolean EsIgualA(Posicion otraPosicion)
        {
            return (this.fila == otraPosicion.fila && this.columna == otraPosicion.columna);
        }
        public Boolean Equals(Posicion otraPosicion)
        {
            return this.EsIgualA(otraPosicion);
        }

        public List<Posicion> GetPosicionesEnUnRadioDe(int r)
        {
            List<Posicion> posiciones = new List<Posicion>();

            for (int i = this.fila - r; i <= this.fila + r; i++)
            {
                for (int j = this.columna - r; j <= this.columna + r; j++)
                {
                    if (!(i == this.fila && j == this.columna))
                    {
                        posiciones.Add(new Posicion(i, j));
                    }
                }
            }

            return posiciones;
        }
    }
}
