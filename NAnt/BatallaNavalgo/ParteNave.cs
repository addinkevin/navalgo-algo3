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

        /*Obtiene la resistencia de la ParteNave*/
        public int GetResistencia() 
        {
            return resistencia;
        }

        /*Constructor de ParteNave*/
        public ParteNave(int resistenciaInicial, Posicion posicionInicial) 
        {
            this.resistencia = resistenciaInicial;
            this.posicionActual = posicionInicial;
        }
        //-----------------------------------------------------------
        /*La parte recibe un ataque*/
        public void RecibirAtaque()
        {
            resistencia -= 1;
        }

        /*Devuelve la posicion de la ParteNave*/
        public Posicion Posicion
        {
            get { return posicionActual; }
            set { posicionActual = value; }
        }
        
        /*Estado de la ParteNave*/
        public Boolean EstaDestruida()
        {
            return (resistencia <= 0);
        }
        //-----------------------------------------------------------

    }
}
