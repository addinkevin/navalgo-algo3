using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public interface Observable
    {
        void AddObservador(Observador observador);
        void NotificarObservadores();
        void NotificarObservadoresDeCreacionDeLancha(Nave nave);
        void NotificarObservadoresDeCreacionDeDestructor(Nave nave);
        void NotificarObservadoresDeCreacionDePortaAviones(Nave nave);
        void NotificarObservadoresDeCreacionDeRompeHielo(Nave nave);
        void NotificarObservadoresDeCreacionDeBuque(Nave nave);
        void NotificarObservadoresDeCreacionDeMinaPorContacto(MinaPorContacto mina);
        void NotificarObservadoresDeCreacionDeMinaConRetardo(MinaConRetardo mina);
    }
}
