using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public interface Observador
    {
        void NotificarCreacionDeLancha(Nave nave);
        void NotificarCreacionDeDestructor(Nave nave);
        void NotificarCreacionDePortaAviones(Nave nave);
        void NotificarCreacionDeRompeHielo(Nave nave);
        void NotificarCreacionDeBuque(Nave nave);
        void NotificarCreacionDeMinaPorContacto(MinaPorContacto mina);
        void NotificarCreacionDeMinaConRetardo(MinaConRetardo mina);
        void Update();
    }
}
