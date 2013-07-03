using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Posicion : IEquatable<Posicion>
    {
        private int fila, columna;
        private static Random numeroAleatorio = new Random();

        /*Contructor de Posicion*/
        public Posicion(int fila, int columna)
        {
            this.fila = fila;
            this.columna = columna;
        }

        /*Funcion para obtener una posicino aleatoria, donde la fila está entre filaMin y filaMax;
         * y la columna está entre columnaMin y columnaMax */
        public static Posicion HacerAleatoria(int filaMin, int filaMax, int columnaMin, int columnaMax) 
        {
            int fila = numeroAleatorio.Next(filaMin, filaMax + 1);
            int columna = numeroAleatorio.Next(columnaMin, columnaMax + 1);
            Posicion posicion = new Posicion(fila, columna);
            return posicion;
        }
        
        public int Fila 
        {
            get { return fila; }
        }
        
        public int Columna
        {
            get { return columna; }
        }               
        

        /*Si una posicion se encuentra dentro de posicion1 y posicion2*/
        public Boolean EstaDentroDe(Posicion posicion1, Posicion posicion2)
        {
            Boolean dentroDeFilas = (this.fila >= posicion1.Fila && this.fila <= posicion2.Fila);
            Boolean dentroDeColumnas = (this.columna >= posicion1.Columna && this.columna <= posicion2.Columna);
            return (dentroDeFilas && dentroDeColumnas);
        }

        /*Si una posicion es igual a otra posicion*/
        public Boolean EsIgualA(Posicion otraPosicion)
        {
            return (this.fila == otraPosicion.fila && this.columna == otraPosicion.columna);
        }
        public Boolean Equals(Posicion otraPosicion)
        {
            return this.EsIgualA(otraPosicion);
        }

        /*Devuelve posiciones que se encutren dentro de un radio r*/
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
