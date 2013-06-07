using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    class Nave
    {
        public static int VERTICAL = 0;
        public static int HORIZONTAL = 1;

        private List<ParteNave> partes;
        private Boolean destruida;

        public Nave(int numeroDePartes, int resistenciaDePartes, Posicion posicionInicial, int orientacion)
        {
            this.destruida = false;
            this.CrearPartes(numeroDePartes, resistenciaDePartes, posicionInicial, orientacion);
        }
        //-----------------------------------------------------------

        private Boolean ValidarPosicion(Posicion posicion)
        {
            Boolean posicionValida = posicion.EstaDentroDe( Tablero.MIN_FILA, Tablero.MIN_COLUMNA, Tablero.MAX_FILA, Tablero.MAX_COLUMNA);
            return posicionValida;
        }

        private void CrearPartes(int numeroDePartes, int resistencia, Posicion posicionInicial, int orientacion)
        {
            partes = new List<ParteNave>();
            Posicion posicion = posicionInicial;
            for (int i = 0; i < numeroDePartes; i++)
            {
                if (!this.ValidarPosicion(posicion))
                {
                    throw new Exception();
                }
                partes.Add(new ParteNave(resistencia, posicion));
                if (orientacion == VERTICAL)
                {
                    posicion.SetFila(posicion.GetFila() + 1);
                }
                else
                {
                    posicion.SetColumna(posicion.GetColumna() + 1);
                }
            }
        }

        public Boolean EstaDestruida() 
        {
            return this.destruida;
        }
        //-----------------------------------------------------------


    }
}
