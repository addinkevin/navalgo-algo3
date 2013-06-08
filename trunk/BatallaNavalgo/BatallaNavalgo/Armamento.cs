using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    abstract class Armamento
    {
        protected Posicion posicion;
        protected int costo;
        protected Boolean explotado;

        public void Atacar(Atacable i)
        {

        }
        //-----------------------------------------------------------

        public void Actualizar()
        {

        }
        //-----------------------------------------------------------

        public Boolean EstaExplotado()
        {
            return this.explotado;
        }
        //-----------------------------------------------------------

    }
}