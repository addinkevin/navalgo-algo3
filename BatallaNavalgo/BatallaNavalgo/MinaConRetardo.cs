using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class MinaConRetardo: Mina
    {
        private int retardo;
        private int radio;
        private Boolean estaExplotado;

        /* Constructor.
         * Radio: Cantidad de casillas adyacentes a la posicion de la mina, en la cual tiene rango de acción.
         * Retardo: Cantidad de Actualizaciones que puede recibir la mina, para luego explotar.
         */
        public MinaConRetardo(int radio, int retardo) 
        {
            this.estaExplotado = false;
            this.retardo = retardo;
            this.radio = radio;
        }

        /* Actualizacion del retardo de la mina */
        public override void Actualizar()
        {
            if (retardo <= 0) return;

            retardo -= 1;   // Actualizacion del retardo

            if (retardo == 0)
            {
                estaExplotado = true;
            }

        }

        /* Devuelve true si la mina ya fue explotada */
        public override Boolean EstaExplotado()
        {
            return estaExplotado;
        }
    }
}
