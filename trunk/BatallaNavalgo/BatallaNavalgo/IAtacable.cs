using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public interface IAtacable
    {
        void RecibirAtaque(DisparoComun disparo, Posicion posicion);
        void RecibirAtaque(Mina mina, Posicion posicion);
    }
}
