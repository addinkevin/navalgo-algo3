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

        /* Setea la posicion del Armamento */
        public void SetPosicion(Posicion posicion)
        {
            this.posicion = posicion;
        }

        /* Devuelve la posicion del Armamento */
        public Posicion GetPosicion()
        {
            return posicion;
        }

        /* Setea el costo del disparo */
        public void SetCosto(int costo)
        {
            this.costo = costo;
        }

        /* Devuelve el costo del disparo */
        public int GetCosto()
        {
            return costo;
        }
    }
}