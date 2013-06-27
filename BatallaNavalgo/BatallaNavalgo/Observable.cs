using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public interface Observable
    {
        void AddObservador(Observador observador);
        void NotificarObservadoresDeCreacionDeLancha(Nave nave);
        void NotificarObservadoresDeCreacionDeDestructor(Destructor nave);
        void NotificarObservadoresDeCreacionDePortaAviones(Nave nave);
        void NotificarObservadoresDeCreacionDeRompeHielo(Nave nave);
        void NotificarObservadoresDeCreacionDeBuque(Buque nave);
        void NotificarObservadoresDeCreacionDeMinaPorContacto(MinaPorContacto mina);
        void NotificarObservadoresDeCreacionDeMinaConRetardo(MinaConRetardo mina);
    }
}
