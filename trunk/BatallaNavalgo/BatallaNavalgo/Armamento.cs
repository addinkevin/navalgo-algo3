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

        public Boolean Explotado         
        {
            get { return estaExplotado; }            
        }

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