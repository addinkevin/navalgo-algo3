using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Batalla_Navalgo
{
    class Nave
    {
        private List<Parte> partes;
        private int cantidadDePartes;
        private Boolean destruida;

        public Nave(int NumeroDePartes)
        {
            this.destruida = false;
            this.cantidadDePartes = NumeroDePartes;
            this.partes = new List<Parte>();
            // CREACION DE NAVE
        }
        //-----------------------------------------------------------

        public Boolean EstaDestruida() 
        {
            return this.destruida;
        }
        //-----------------------------------------------------------


    }
}
