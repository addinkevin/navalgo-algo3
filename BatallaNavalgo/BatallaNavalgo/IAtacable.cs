using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    interface IAtacable
    {
        void RecibirAtaque(DisparoComun disparo);
        void RecibirAtaque(Mina mina);
    }
}
