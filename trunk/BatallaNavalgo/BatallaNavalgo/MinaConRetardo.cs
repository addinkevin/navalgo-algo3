﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class MinaConRetardo: Mina
    {
        private int retardo;

        //-----------------------------------------------------------
        public MinaConRetardo(int radio, int costo, int retardo, Posicion posicionInicial) 
        {
            this.radio = radio;
            this.costo = costo;
            this.retardo = retardo;
            this.posicion = posicionInicial;
            this.explotado = false;
        }

        //-----------------------------------------------------------
        public override void Actualizar() 
        {
        }

        //-----------------------------------------------------------
    }
}
