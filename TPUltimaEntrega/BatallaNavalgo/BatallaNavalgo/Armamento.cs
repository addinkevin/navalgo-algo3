using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public abstract class Armamento
    {
        private int costo;
        private Posicion posicion;
        private Tablero tablero;
        protected Boolean estaExplotado;

        public abstract void Actualizar();       

        /* Estado del Armamento*/
        public Boolean Explotado         
        {
            get { return estaExplotado; }            
        }

        /* Tablero donde se encuentra el Armamento*/
        public Tablero TableroEnElQueEsta 
        {
            get { return tablero; }
            set { tablero = value; }
        }       

        /* Posicion del Armamento */
        public Posicion Posicion
        {
            get { return this.posicion; }
            set { this.posicion = value; }
        }

        /* Costo del disparo */
        public int Costo
        {
            get { return this.costo; }
            set { this.costo = value; }
        }
    }
}