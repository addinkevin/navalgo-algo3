using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgoExcepciones;

namespace BatallaNavalgo
{
    public class Nave
    {
        public static int VERTICAL = 0;
        public static int HORIZONTAL = 1;
        
        private List<ParteNave> partes;

        public Nave(int numeroDePartes, int resistenciaDePartes, Posicion posicionInicial, int orientacion)
        {
            this.CrearPartes(numeroDePartes, resistenciaDePartes, posicionInicial, orientacion);
        }
        //-----------------------------------------------------------

        private Boolean ValidarPosicion(Posicion posicion)
        {
            Boolean valida = posicion.EstaDentroDe(Tablero.ESQUINA_IZQUIERDA_ARRIBA, Tablero.ESQUINA_DERECHA_ABAJO);
            return valida;
        }

        private void CrearPartes(int numeroDePartes, int resistencia, Posicion posicionInicial, int orientacion)
        {
            partes = new List<ParteNave>();
            Posicion posicion = posicionInicial;
            for (int i = 0; i < numeroDePartes; i++)
            {
                if (!this.ValidarPosicion(posicion))
                {
                    throw new ImposibleCrearNaveException();
                }
                partes.Add(new ParteNave(resistencia, posicion));
                if (orientacion == VERTICAL)
                {
                    posicion = new Posicion(posicion.GetFila() + 1, posicion.GetColumna());
                }
                else
                {
                    posicion = new Posicion(posicion.GetFila(), posicion.GetColumna() + 1);
                }
            }
        }

        public List<Posicion> GetPosiciones()
        {
            List<Posicion> lista = new List<Posicion>();
            foreach ( ParteNave parte in partes)
            {
                lista.Add(parte.GetPosicion());
            }
            return lista;
        }

        public Boolean EstaDestruida() 
        {
            foreach (ParteNave parte in partes)
            {
                if (!parte.EstaDestruida())
                {
                    return false;
                }
            }
            return true;
        }
        
        //-----------------------------------------------------------
        public void RecibirAtaque(DisparoComun disparo)
        {
            foreach (ParteNave parte in partes)
            {
                if (parte.GetPosicion().EsIgualA(disparo.GetPosicion()))
                {
                    parte.RecibirAtaque();
                    return;
                }

            }
        }
        


    }
}
