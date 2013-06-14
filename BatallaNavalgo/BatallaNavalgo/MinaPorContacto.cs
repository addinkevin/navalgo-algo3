using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class MinaPorContacto: Mina
    {
        
        public MinaPorContacto(Tablero tablero, Posicion posicion, int costo) 
        {
            base.TableroEnElQueEsta = tablero;
            base.Posicion = posicion;
            base.Costo = costo;
            this.Radio = 0;            
            estaExplotado = false;        
        }
        
        /* Actualiza la mina por contacto. Explota si hay alguna nave en su posición */
        public override void Actualizar() 
        {
            if (this.Explotado) return;

            if (this.TableroEnElQueEsta.HayNave(this.Posicion)) 
            {
                estaExplotado = true;
                List<Nave> naves = this.TableroEnElQueEsta.GetNavesEn(this.Posicion);

                DispararA(naves);
            }
        }

        //-----------------------------------------------------------
        


        /* Dispara a cada una de las naves en la lista */
        private void DispararA(List<Nave> naves)
        {
            foreach (Nave nave in naves)
            {
                nave.RecibirAtaque(this, this.Posicion);
            }
        }
        /* ---------------------------------------------*/
    }
}
