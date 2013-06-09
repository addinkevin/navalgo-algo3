using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class ArmamentoFactory
    {
        public static DisparoComun CrearDisparoComun(Posicion posicion)
        {
            DisparoComun disparo = new DisparoComun();
            disparo.SetPosicion(posicion);
            disparo.SetCosto(200);
            return disparo;
        }

        public static MinaConRetardo CrearMinaPuntual(Posicion posicion)
        {
            MinaConRetardo mina = new MinaConRetardo(0,3);
            mina.SetPosicion(posicion);
            mina.SetCosto(50);
            return mina;
        }

        public static MinaConRetardo CrearMinaDoble(Posicion posicion)
        {
            MinaConRetardo mina = new MinaConRetardo(1, 3);
            mina.SetPosicion(posicion);
            mina.SetCosto(100);
            return mina;
        }

        public static MinaConRetardo CrearMinaTriple(Posicion posicion)
        {
            MinaConRetardo mina = new MinaConRetardo(2, 3);
            mina.SetPosicion(posicion);
            mina.SetCosto(125);
            return mina;
        }

        public static MinaPorContacto CrearMinaPorContacto(Posicion posicion)
        {
            MinaPorContacto mina = new MinaPorContacto();
            mina.SetPosicion(posicion);
            mina.SetCosto(150);
            return mina;
        }
    }
}
