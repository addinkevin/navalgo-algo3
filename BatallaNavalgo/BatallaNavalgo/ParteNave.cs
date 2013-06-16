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

        public int GetResistencia() 
        {
            return resistencia;
        }

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

        public Posicion Posicion
        {
            get { return posicionActual; }
            set { posicionActual = value; }
        }
        
        public Boolean EstaDestruida()
        {
            return (resistencia <= 0);
        }
        //-----------------------------------------------------------

    }
}
