using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class DisparoComun: Armamento
    {
       

        public DisparoComun()
        {
            estaExplotado = false;
        }

        /* Dispara a cada una de las naves en la lista */
        private void DispararA(List<Nave> naves)
        {
            foreach (Nave nave in naves)
            {
                nave.RecibirAtaque(this,this.Posicion);
            }
        }

        /* Realiza la actualicion del disparo.*/
        public override void Actualizar() 
        {
            if (this.Explotado) return;

            List<Nave> naves = this.TableroEnElQueEsta.GetNavesEn(this.Posicion);

            DispararA(naves);
            
            estaExplotado = true;
        }

       
        
    }
}
