using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class MinaConRetardo: Mina
    {
        private int retardo;                

        /* Constructor.
         * Radio: Cantidad de casillas adyacentes a la posicion de la mina, en la cual tiene rango de acción.
         * Retardo: Cantidad de Actualizaciones que puede recibir la mina, para luego explotar.
         */
        public MinaConRetardo(Tablero tablero, Posicion posicion, int costo, int radio, int retardo) 
        {
            base.TableroEnElQueEsta = tablero;
            base.Posicion = posicion;
            base.Costo = costo;
            this.estaExplotado = false;
            this.retardo = retardo;
            this.Radio = radio;
        }

        /* Actualizacion del retardo de la mina */
        public override void Actualizar()
        {
            if (this.estaExplotado) return;

            retardo -= 1;   // Actualizacion del retardo

            if (retardo == 0)
            {
                Explotar();
                estaExplotado = true;
            }
        }

        private void Explotar() 
        {
            List<Posicion> posicionesAImpactar = this.Posicion.GetPosicionesEnUnRadioDe(this.Radio);
            posicionesAImpactar.Add(this.Posicion);

            foreach (Posicion posicion in posicionesAImpactar)
            {
                List<Nave> naves = this.TableroEnElQueEsta.GetNavesEn(posicion);
                DispararA(naves, posicion);
            }
        }

        /* Ataca a las naves */
        private void DispararA(List<Nave> naves, Posicion posicion)
        {
            foreach (Nave nave in naves)
            {
                nave.RecibirAtaque(this, posicion);
            }
        }        
    }
}
