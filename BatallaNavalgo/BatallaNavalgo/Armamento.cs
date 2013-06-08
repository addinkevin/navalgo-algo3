using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
    
{
    public abstract class Armamento
    {
        protected int costo;
        protected Boolean explotado;
        protected Posicion posicion;

        public abstract void Atacar(IAtacable i);
       
        //-----------------------------------------------------------

        public abstract void Actualizar();        
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