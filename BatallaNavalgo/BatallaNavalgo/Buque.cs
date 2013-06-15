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

        public Buque(Posicion posicionInicial, Orientacion orientacion)
            :base(NUMERO_DE_PARTES_DEL_BUQUE , RESISTENCIA_DE_PARTES_DEL_BUQUE,
                  posicionInicial,orientacion)
        {
            estaDestruida = false;
        }
        
        public override void RecibirAtaque(DisparoComun disparo, Posicion posicion)
        {
            estaDestruida = true;
        }
        public override void RecibirAtaque(Mina mina, Posicion posicion)
        {
            estaDestruida = true;
        }
               
        public override Boolean EstaDestruida()
        {
            return estaDestruida;
        }        

    }
}
