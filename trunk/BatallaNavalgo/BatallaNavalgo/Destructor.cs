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
        public Destructor(Posicion posicionInicial, int orientacion)
            : base(NUMERO_DE_PARTES_DEL_DESTRUCTOR, RESISTENCIA_DE_PARTES_DEL_DESTRUCTOR,
                    posicionInicial, orientacion)
        {
        }

        public override void  RecibirAtaque(DisparoComun disparo)
        {
 	        base.RecibirAtaque(disparo);
        }

        public override void RecibirAtaque(Mina mina)
        {
            //No hace nada. No le afecta las minas.
        }
    }
}
