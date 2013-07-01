using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public abstract class Mina: Armamento
    {
        private int radio;

        public int Radio 
        {
            get { return radio; }
            set { radio = value; }
        }
        
    }
}
