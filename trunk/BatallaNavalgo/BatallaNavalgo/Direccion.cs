using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Direccion
    {
        public static int FILAS = 10;
        public static int COLUMNAS = 10;

        private int movimientoEnFilas;
        private int movimientoEnColumnas;

        public Direccion(int movimientoEnFilas, int movimientoEnColumnas)
        {
            this.movimientoEnColumnas = movimientoEnColumnas;
            this.movimientoEnFilas = movimientoEnFilas;
        }

        private Boolean ChocaEnFilas(int filaActual) 
        {
            if ((movimientoEnFilas == 1) && (filaActual == FILAS)) 
            {
                return true;
            }

            if ( (movimientoEnFilas == (-1) ) && (filaActual == 1))
            {
                return true;
            }

            return false;
        }

        private Boolean ChocaEnColumnas(int columnaActual)
        {
            if ((movimientoEnColumnas == 1) && (columnaActual == COLUMNAS))
            {
                return true;
            }

            if ((movimientoEnColumnas == (-1)) && (columnaActual == 1))
            {
                return true;
            }

            return false;
        }

        private void ValidarMovimientoParaPosicionSiguiente(Posicion posicionActual)
        {
            int columnaActual, filaActual;
            columnaActual = posicionActual.GetColumna();
            filaActual = posicionActual.GetFila();

            if (ChocaEnFilas(filaActual) || ChocaEnColumnas(columnaActual))             
            {
                Invertir();
            }
        
        }

        /* Obtiene una nueva posicion, en base al movimiento de filas y columnas de la direccion */
        public Posicion GetNuevaPosicion(Posicion pos){
            ValidarMovimientoParaPosicionSiguiente(pos);
            int filaNueva = pos.GetFila() + movimientoEnFilas;
            int columnaNueva = pos.GetColumna() + movimientoEnColumnas;

            return new Posicion(filaNueva,columnaNueva);
        }

        /* Invierte el sentido de la direccion */
        public void Invertir()
        {
            movimientoEnColumnas *= -1;
            movimientoEnFilas *= -1;
        }

    }
}
