using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Mina: Armamento
    {
        private Posicion posicion;
        private int costo;

        public Mina(Posicion posicionInicial)
        {
            posicion = posicionInicial;
        }

        public Posicion GetPosicion()
        {
            return posicion;
        }

        public void SetCosto(int costo)
        {
            this.costo = costo;
        }

        public int GetCosto()
        {
            return costo;
        }

    }
}
