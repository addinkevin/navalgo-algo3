using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class MinaPorContacto: Mina
    {
        public MinaPorContacto(int radio, int costo, Posicion posicionInicial) 
        {
            this.radio = radio;
            this.costo = costo;            
            this.posicion = posicionInicial;
            this.explotado = false;
        }
        //-----------------------------------------------------------

        public override void Actualizar()
        { 
        
        }
        //-----------------------------------------------------------

        public override void Atacar(IAtacable atacable) 
        {

        }
        //-----------------------------------------------------------
       
    }
}
