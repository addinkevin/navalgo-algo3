using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    class ArmamentoFactory
    {
        public static Armamento CrearMinaPuntual(Posicion posicion)
        {
            return new MinaConRetardo(0, 50, 3, posicion);
        }

        public static Armamento CrearMinaDoble(Posicion posicion)
        {
            return new MinaConRetardo(1, 100, 3, posicion);
        }

        public static Armamento CrearMinaTriple(Posicion posicion)
        {
            return new MinaConRetardo(2, 125, 3, posicion);
        }

        public static Armamento CrearMinaPorContacto(Posicion posicion)
        {
            return new MinaPorContacto(0, 150, posicion);
        }
    }
}
