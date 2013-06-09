﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class DisparoComun: Armamento
    {
        private Boolean estaExplotado;

        public DisparoComun()
        {
            estaExplotado = false;
        }

        /* Dispara a cada una de las naves en la lista */
        private void DispararA(List<Nave> naves)
        {
            foreach (Nave nave in naves)
            {
                nave.RecibirAtaque(this);
            }
        }

        /* Realiza la actualicion del disparo.*/
        public override void Actualizar() 
        {
            if (EstaExplotado()) return;

            List<Nave> naves = GetTablero().GetNavesEn(GetPosicion());

            DispararA(naves);
            
            estaExplotado = true;
        }

        public override Boolean EstaExplotado()
        {
            return estaExplotado;
        }
    }
}