using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class ParteNave
    {
        private int resistencia;
        private Posicion posicionActual;

        public ParteNave(int resistenciaInicial, Posicion posicionInicial) 
        {
            this.resistencia = resistenciaInicial;
            this.posicionActual = posicionInicial;
        }
        //-----------------------------------------------------------

        public void RecibirAtaque()
        {
            resistencia -= 1;
        }

        public Posicion GetPosicion() {
            return posicionActual;
        }

        public Boolean EstaDestruida()
        {
            return (resistencia <= 0);
        }
        //-----------------------------------------------------------

    }
}
