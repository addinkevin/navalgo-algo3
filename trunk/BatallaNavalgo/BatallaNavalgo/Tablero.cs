using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Tablero
    {
        public static Posicion ESQUINA_IZQUIERDA_ARRIBA = new Posicion(1, 1);
        public static Posicion ESQUINA_DERECHA_ABAJO = new Posicion(10, 10);
        private List<Armamento> armamentos;
        private List<Nave> naves;

        /* Constructor
         * armamentos: seran los armamentos que se encuentren en el tablero.
         * posicionInicial: seran las naves que se encuentren en el talero.
         */
        public Tablero()
        {
            armamentos = new List<Armamento>();
            naves = new List<Nave>();
        }

        public void AgregarNave(Nave nave) 
        {
            naves.Add(nave);
        }

        public void Impactar(Armamento arma) 
        {
            armamentos.Add(arma);
        }

        /*public void Actualizar() 
        {
        }
        */

        public Boolean HayNave(Posicion posicion) 
        {
            foreach (Nave nave in naves)
            {
                List<Posicion> listaPosiciones = (nave.GetPosiciones());
                foreach (Posicion posicionParteNave in listaPosiciones)
                {
                    if (posicion.EsIgualA(posicionParteNave))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean HayMina(Posicion posicion)
        {
            foreach (Armamento mina in armamentos)
            {
                Posicion posicionMina = mina.GetPosicion();
                if (posicion.EsIgualA(posicionMina))
                {
                    return true;
                }
            }
            return false;
        }

        public void ActualizarPosicionDeNaves() 
        {
            foreach (Nave nave in naves)
            {
                nave.Mover();
            }
        }

        public Boolean EstaVacio()
        {
            if ((naves.Count()).Equals(0) && (armamentos.Count()).Equals(0))
            {
                return true;
            }
            return false;
        }

        public List<Nave> GetNavesEn(Posicion posicion)
        {
            List<Nave> listaNavesEnPosicion = new List<Nave>();
            foreach (Nave nave in naves)
            {
                List<Posicion> listaPosicionesDePartes = (nave.GetPosiciones());
                foreach (Posicion posicionParteNave in listaPosicionesDePartes)
                {
                    if (posicion.EsIgualA(posicionParteNave))
                    {
                        listaNavesEnPosicion.Add(nave);
                    }
                }
            }
            return listaNavesEnPosicion;
        }
    }
}
