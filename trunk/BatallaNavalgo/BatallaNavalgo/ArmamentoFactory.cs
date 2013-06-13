using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class ArmamentoFactory
    {
		/*Crea y devuelve DisparoComun valido*/
        public static DisparoComun CrearDisparoComun(Posicion posicion)
        {
            DisparoComun disparo = new DisparoComun();
            disparo.Posicion = posicion;
            disparo.Costo = 200;
            return disparo;
        }

		/*Crea y devuelve MinaConRetardo valida*/
        public static MinaConRetardo CrearMinaPuntual(Posicion posicion)
        {
            MinaConRetardo mina = new MinaConRetardo(0,3);
            mina.Posicion = posicion;
            mina.Costo = 50;
            return mina;
        }

		/*Crea y devuelve MinaConRetardo valida*/
        public static MinaConRetardo CrearMinaDoble(Posicion posicion)
        {
            MinaConRetardo mina = new MinaConRetardo(1, 3);
            mina.Posicion = posicion;
            mina.Costo = 100;
            return mina;
        }

		/*Crea y devuelve MinaConRetardo valida*/
        public static MinaConRetardo CrearMinaTriple(Posicion posicion)
        {
            MinaConRetardo mina = new MinaConRetardo(2, 3);
            mina.Posicion = posicion;
            mina.Costo = 125;
            return mina;
        }

		/*Crea y devuelve MinaPorContacto valida*/
        public static MinaPorContacto CrearMinaPorContacto(Posicion posicion)
        {
            MinaPorContacto mina = new MinaPorContacto();
            mina.Posicion = posicion;
            mina.Costo = 150;
            return mina;
        }
    }
}

