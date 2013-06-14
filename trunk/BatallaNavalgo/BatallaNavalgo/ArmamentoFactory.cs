using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class ArmamentoFactory
    {
		/*Crea y devuelve DisparoComun valido*/
        public static DisparoComun CrearDisparoComun(Tablero tablero, Posicion posicion)
        {
            DisparoComun disparo = new DisparoComun(tablero, posicion, 200);
            return disparo;
        }

		/*Crea y devuelve MinaConRetardo valida*/
        public static MinaConRetardo CrearMinaPuntual(Tablero tablero, Posicion posicion)
        {
            int radio = 0;
            int retardo = 3;
            int costo = 50;
            MinaConRetardo mina = new MinaConRetardo(tablero, posicion,costo, radio,retardo);
            return mina;
        }

		/*Crea y devuelve MinaConRetardo valida*/
        public static MinaConRetardo CrearMinaDoble(Tablero tablero, Posicion posicion)
        {
            int radio = 1;
            int retardo = 3;
            int costo = 100;
            MinaConRetardo mina = new MinaConRetardo(tablero, posicion, costo, radio, retardo);
            return mina;
        }

		/*Crea y devuelve MinaConRetardo valida*/
        public static MinaConRetardo CrearMinaTriple(Tablero tablero, Posicion posicion)
        {
            int radio = 2;
            int retardo = 3;
            int costo = 125;
            MinaConRetardo mina = new MinaConRetardo(tablero, posicion,costo,radio,retardo);
            return mina;
        }

		/*Crea y devuelve MinaPorContacto valida*/
        public static MinaPorContacto CrearMinaPorContacto(Tablero tablero, Posicion posicion)
        {
            int costo = 150;
            MinaPorContacto mina = new MinaPorContacto(tablero, posicion, costo);
            return mina;
        }
    }
}

