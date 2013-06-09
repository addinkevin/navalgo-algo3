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

        public abstract void Actualizar();        

        public abstract Boolean EstaExplotado();

        /* Setea el tablero en el cual se ubica el Armamento */
        public void SetTablero(Tablero tablero)
        {
            this.tablero = tablero;
        }

        /* Devuelve el tablero en el cual se encuentra el Armamento */
        public Tablero GetTablero()
        {
            return tablero;
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