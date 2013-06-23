using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Direccion
    {
        public static Direccion Norte = new Direccion(-1, 0);
        public static Direccion Sur = new Direccion(1, 0);
        public static Direccion Este = new Direccion(0, 1);
        public static Direccion Oeste = new Direccion(0, -1);
        public static Direccion Noroeste = new Direccion(-1, -1);
        public static Direccion Noreste = new Direccion(-1, 1);
        public static Direccion Suroeste = new Direccion(1, -1);
        public static Direccion Sureste = new Direccion(1, 1);


        public static Direccion[] DireccionesDisponibles =
        {
            Norte, Sur, Este, Oeste, Noroeste, Noreste, Suroeste, Sureste
        };

        private int movimientoEnFilas;
        private int movimientoEnColumnas;

        private Direccion(int movimientoEnFilas, int movimientoEnColumnas)
        {
            this.movimientoEnColumnas = movimientoEnColumnas;
            this.movimientoEnFilas = movimientoEnFilas;
        }

        /* Obtiene una nueva posicion, en base al movimiento de filas y columnas de la direccion */
        public Posicion GetNuevaPosicion(Posicion pos)
        {
            int filaNueva = pos.Fila + movimientoEnFilas;
            int columnaNueva = pos.Columna + movimientoEnColumnas;

            return new Posicion(filaNueva, columnaNueva);
        }

        private Boolean EsDireccionOpuesta(Direccion otraDireccion)
        {
            return (this.movimientoEnFilas == otraDireccion.movimientoEnFilas * -1) &&
                    (this.movimientoEnColumnas == otraDireccion.movimientoEnColumnas * -1);
        }

        /* Invierte el sentido de la direccion */
        public Direccion Invertir()
        {
            foreach (Direccion direccion in DireccionesDisponibles)
            {
                if (direccion.EsDireccionOpuesta(this))
                    return direccion;
            }
            return this;
        }

    }
}
