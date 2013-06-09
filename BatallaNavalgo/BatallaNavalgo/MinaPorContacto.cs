using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class MinaPorContacto: Mina
    {
        public MinaPorContacto()
        {
            this.radio = 0;
        }

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
