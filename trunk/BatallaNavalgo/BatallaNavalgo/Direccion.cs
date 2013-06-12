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

        public Boolean EsigualA(Direccion direccion)
        {
            if ((this.movimientoEnFilas == direccion.movimientoEnFilas) && (this.movimientoEnColumnas== direccion.movimientoEnColumnas))
            {
                return true;
            }
            return false;
        }


        /*Comprueba si con la fila y direccion actual corresponde invertir el sentido*/
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

        /*Comprueba si con la columna y direccion actual corresponde invertir el sentido*/
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

        /*Comprueba si con la posicion y direccion actual corresponde invertir el sentido*/
        private void ValidarMovimientoParaPosicionSiguiente(Posicion posicionActual)
        {
            int columnaActual, filaActual;
            columnaActual = posicionActual.Columna;
            filaActual = posicionActual.Fila;

            if (ChocaEnFilas(filaActual) || ChocaEnColumnas(columnaActual))             
            {
                Invertir();
            }
        
        }

        /* Obtiene una nueva posicion, en base al movimiento de filas y columnas de la direccion */
        public Posicion GetNuevaPosicion(Posicion pos){
            ValidarMovimientoParaPosicionSiguiente(pos);
            int filaNueva = pos.Fila + movimientoEnFilas;
            int columnaNueva = pos.Columna + movimientoEnColumnas;

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
