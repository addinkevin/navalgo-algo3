using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Direccion
    {
        private int movimientoEnFilas;
        private int movimientoEnColumnas;

        public Direccion(int movimientoEnFilas, int movimientoEnColumnas)
        {
            this.movimientoEnColumnas = movimientoEnColumnas;
            this.movimientoEnFilas = movimientoEnFilas;
        }

        /* Obtiene una nueva posicion, en base al movimiento de filas y columnas de la direccion */
        public Posicion GetNuevaPosicion(Posicion pos){
            int filaNueva = pos.GetFila() + movimientoEnFilas;
            int columnaNueva = pos.GetColumna() + movimientoEnColumnas;

            return new Posicion(filaNueva,columnaNueva);
        }


    }
}
