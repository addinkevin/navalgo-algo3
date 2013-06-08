using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
    
{
    public abstract class Armamento
    {
        protected Posicion posicion;
        protected int costo;
        protected Boolean explotado;

        public void Atacar(IAtacable i)
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


        internal Posicion GetPosicion()
        {
            throw new NotImplementedException();
        }
    }
}