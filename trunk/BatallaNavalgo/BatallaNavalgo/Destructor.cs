using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Destructor: Nave
    {
        private static int NUMERO_DE_PARTES_DEL_DESTRUCTOR = 3;
        private static int RESISTENCIA_DE_PARTES_DEL_DESTRUCTOR = 1;

        /*Constructor de la clase Destructor*/
        public Destructor(Posicion posicionInicial, Orientacion orientacion)
            : base(NUMERO_DE_PARTES_DEL_DESTRUCTOR, RESISTENCIA_DE_PARTES_DEL_DESTRUCTOR,
                    posicionInicial, orientacion)
        {
        }

        /*Comportamiento del Destructor cuando recibe un disparo*/
        public override void  RecibirAtaque(DisparoComun disparo, Posicion posicion)
        {
 	        base.RecibirAtaque(disparo, posicion);
        }

        /*Comportamiento del Destructor cuando recibe una mina*/
        public override void RecibirAtaque(Mina mina, Posicion posicion)
        {
            //No hace nada. No le afecta las minas.
        }

        /*Verificacion para que se cree el Destructor*/
        public static bool SePuedeCrear(Posicion posicionInicial, Orientacion orientacion)
        {
            return Nave.SePuedeCrear(NUMERO_DE_PARTES_DEL_DESTRUCTOR, posicionInicial, orientacion);
        }
    }
}
