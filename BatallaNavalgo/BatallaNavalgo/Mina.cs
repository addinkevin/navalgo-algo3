using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public abstract class Mina: Armamento
    {
        protected int radio;

        //-----------------------------------------------------------
        public Mina()
        {
            this.radio = 0;
        }

        //-----------------------------------------------------------
        public Mina(Posicion posicionInicial)
        {
            posicion = posicionInicial;
        }

        //-----------------------------------------------------------
        public void SetCosto(int costo)
        {
            this.costo = costo;
        }

        //-----------------------------------------------------------
        public int GetCosto()
        {
            return costo;
        }

        public override void Atacar(IAtacable i)
        {
            i.RecibirAtaque(this);
        }

    }
}
