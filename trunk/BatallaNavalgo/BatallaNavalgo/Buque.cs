using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Buque: Nave
    {
        private Boolean estaDestruida;

        public Buque(int numeroDePartes, Posicion posicionInicial, int orientacion)
            :base(numeroDePartes,1,posicionInicial,orientacion)
        {
            estaDestruida = false;
        }


        public override void RecibirAtaque(DisparoComun disparo)
        {
            estaDestruida = true;
        }
        public override  void RecibirAtaque(Mina mina)
        {
            estaDestruida = true;
        }

        public override Boolean EstaDestruida()
        {
            return estaDestruida;
        }

    }
}
