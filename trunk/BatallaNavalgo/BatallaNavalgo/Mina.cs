using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public abstract class Mina: Armamento
    {
        private int radio;

        public void SetRadio(int radio)
        {
            this.radio = radio;
        }

        public int GetRadio() 
        {
            return radio;
        }
    }
}
