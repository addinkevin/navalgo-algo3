using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class MinaPorContacto: Mina
    {
        
        //-----------------------------------------------------------
        public override void Actualizar() 
        {
        }

        //-----------------------------------------------------------
        public override bool EstaExplotado()
        {
            return true;
        }
    }
}
