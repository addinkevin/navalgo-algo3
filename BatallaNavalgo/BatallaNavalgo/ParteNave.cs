using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class ParteNave
    {
        private Boolean destruida;
        private int resistencia;
        private Posicion posicionActual;

        public ParteNave(int resistencia, Posicion posicionInicial) 
        {
            this.destruida = false;
            this.resistencia = resistencia;
            this.posicionActual = posicionInicial;
        }
        //-----------------------------------------------------------

        public Posicion GetPosicion() {
            return posicionActual;
        }

        public Boolean EstaDestruida()
        {
            return this.destruida;
        }
        //-----------------------------------------------------------

    }
}
