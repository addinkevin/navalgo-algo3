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
            this.radio = 0;
            estaExplotado = false;        
        }
        
        //-----------------------------------------------------------
        public override void Actualizar() 
        {
            List<Nave> naves = GetTablero().GetNavesEn(GetPosicion());

            DispararA(naves);

            if (HaceContactoConNave(naves)) 
            {
                estaExplotado = true;
            }
        }

        /* Comprueba colisión de mina con alguna nave */
        private bool HaceContactoConNave(List<Nave> naves)
        {
            foreach (Nave nave in naves) 
            {
                List<Posicion> posicionesDeNave = nave.GetPosiciones();
                foreach (Posicion posicion in posicionesDeNave) 
                {
                    if (posicion.EsIgualA(this.GetPosicion()))
                    {
                        return true;
                    }
                }                              
            }
            return false;
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
                nave.RecibirAtaque(this);
            }
        }
        /* ---------------------------------------------*/
    }
}
