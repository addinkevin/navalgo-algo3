using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Buque: Nave
    {
        private static int NUMERO_DE_PARTES_DEL_BUQUE = 4;
        private static int RESISTENCIA_DE_PARTES_DEL_BUQUE = 1;
        private Boolean estaDestruida;

        /*Constructor de la clase Buque*/
        public Buque(Posicion posicionInicial, Orientacion orientacion, Direccion direccion)
            :base(NUMERO_DE_PARTES_DEL_BUQUE , RESISTENCIA_DE_PARTES_DEL_BUQUE,
                  posicionInicial,orientacion,direccion)
        {
            estaDestruida = false;
        }
        
        /*Comportamiento del Buque cuando recibe un disparo*/
        public override void RecibirAtaque(DisparoComun disparo, Posicion posicion)
        {
            estaDestruida = true;
        }

        /*Comportamiento del Buque cuando recibe una mina*/
        public override void RecibirAtaque(Mina mina, Posicion posicion)
        {
            estaDestruida = true;
        }
        
        /*Estado del Buque*/
        public override Boolean EstaDestruida()
        {
            return estaDestruida;
        }
        
        /*Verificacion para que se cree el Buque*/
        public static bool SePuedeCrear(Posicion posicionInicial, Orientacion orientacion)
        {
            return Nave.SePuedeCrear(NUMERO_DE_PARTES_DEL_BUQUE, posicionInicial,orientacion);
        }

    }
}
