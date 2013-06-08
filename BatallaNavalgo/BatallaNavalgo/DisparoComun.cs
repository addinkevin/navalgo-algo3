using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class DisparoComun: Armamento
    {
       
        public DisparoComun(Posicion posicion)
        {
            this.posicion = posicion;
        }
        

        public void SetCosto(int costo)
        {
            this.costo = costo;
        }

        public int GetCosto()
        {
            return costo;
        }

        //-----------------------------------------------------------
        public override void Atacar(IAtacable i) 
        {
        }
        //-----------------------------------------------------------

        public override void Actualizar() 
        { 
        }
    }
}
