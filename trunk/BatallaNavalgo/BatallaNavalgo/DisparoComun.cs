using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class DisparoComun
    {
        private int costo = 0;
        private Posicion posicion;

        public DisparoComun(Posicion posicion)
        {
            this.posicion = posicion;
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
