using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class MinaPorContacto: Mina
    {
        private Boolean estaExplotado;

        public MinaPorContacto() 
        {
            SetRadio(0);
            estaExplotado = false;        
        }
        
        /* Actualiza la mina por contacto. Explota si hay alguna nave en su posición */
        public override void Actualizar() 
        {
            if (EstaExplotado()) return;

            if (GetTablero().HayNave(GetPosicion())) 
            {
                estaExplotado = true;
                List<Nave> naves = GetTablero().GetNavesEn(GetPosicion());

                DispararA(naves);
            }
        }

        //-----------------------------------------------------------
        public override bool EstaExplotado()
        {
            return this.estaExplotado;
        }


        /* Dispara a cada una de las naves en la lista */
        private void DispararA(List<Nave> naves)
        {
            foreach (Nave nave in naves)
            {
                nave.RecibirAtaque(this, GetPosicion());
            }
        }
        /* ---------------------------------------------*/
    }
}
