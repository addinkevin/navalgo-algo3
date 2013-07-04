using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class ArmamentoFactory
    {
        public static int COSTO_DISPARO_COMUN = 200;
        public static int COSTO_MINA_PUNTUAL = 50;
        public static int COSTO_MINA_DOBLE = 100;
        public static int COSTO_MINA_TRIPLE = 125;
        public static int COSTO_MINA_POR_CONTACTO = 150;

		/*Crea y devuelve DisparoComun valido*/
        public static DisparoComun CrearDisparoComun(Tablero tablero, Posicion posicion)
        {
            DisparoComun disparo = new DisparoComun(tablero, posicion, COSTO_DISPARO_COMUN);
            return disparo;
        }

		/*Crea y devuelve MinaConRetardo valida*/
        public static MinaConRetardo CrearMinaPuntual(Tablero tablero, Posicion posicion)
        {
            int radio = 0;
            int retardo = 3;
            MinaConRetardo mina = new MinaConRetardo(tablero, posicion,COSTO_MINA_PUNTUAL, radio,retardo);
            return mina;
        }

		/*Crea y devuelve MinaConRetardo valida*/
        public static MinaConRetardo CrearMinaDoble(Tablero tablero, Posicion posicion)
        {
            int radio = 1;
            int retardo = 3;
            MinaConRetardo mina = new MinaConRetardo(tablero, posicion, COSTO_MINA_DOBLE, radio, retardo);
            return mina;
        }

		/*Crea y devuelve MinaConRetardo valida*/
        public static MinaConRetardo CrearMinaTriple(Tablero tablero, Posicion posicion)
        {
            int radio = 2;
            int retardo = 3;
            MinaConRetardo mina = new MinaConRetardo(tablero, posicion,COSTO_MINA_TRIPLE,radio,retardo);
            return mina;
        }

		/*Crea y devuelve MinaPorContacto valida*/
        public static MinaPorContacto CrearMinaPorContacto(Tablero tablero, Posicion posicion)
        {
            MinaPorContacto mina = new MinaPorContacto(tablero, posicion, COSTO_MINA_POR_CONTACTO);
            return mina;
        }
    }
}

