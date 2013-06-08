using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class ArmamentoFactory
    {
        public static MinaConRetardo CrearMinaPuntual(Posicion posicion)
        {
            return new MinaConRetardo(0, 50, 3, posicion);
        }

        public static MinaConRetardo CrearMinaDoble(Posicion posicion)
        {
            return new MinaConRetardo(1, 100, 3, posicion);
        }

        public static MinaConRetardo CrearMinaTriple(Posicion posicion)
        {
            return new MinaConRetardo(2, 125, 3, posicion);
        }

        public static MinaPorContacto CrearMinaPorContacto(Posicion posicion)
        {
            return new MinaPorContacto(0, 150, posicion);
        }
    }
}
