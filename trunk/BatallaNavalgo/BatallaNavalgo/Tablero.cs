using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgoExcepciones;

namespace BatallaNavalgo
{
    public class Tablero
    {
        private static int CANTIDAD_DE_FILAS = 10;
        private static int CANTIDAD_DE_COLUMNAS = 10;
        public static Posicion ESQUINA_IZQUIERDA_ARRIBA = new Posicion(1, 1);
        public static Posicion ESQUINA_DERECHA_ABAJO = new Posicion(10, 10);
        private List<Armamento> armamentos;
        private List<Nave> naves;
        
        /*Constructor del Tablero*/
        public Tablero()
        {            
            armamentos = new List<Armamento>();
            naves = new List<Nave>();
        }

        /*Devuelve un iterador de las naves del tablero*/
        public List<Nave>.Enumerator DevolverIteradorNaves() 
        {
            return naves.GetEnumerator();            
        }

        /*Devuelve un iterador de los armamentos del tablero*/
        public List<Armamento>.Enumerator DevolverIteradorArmamentos()
        {
            return armamentos.GetEnumerator();
        }

        //---------------------------------------------------------------------
        public static int Filas 
        {
            get { return CANTIDAD_DE_FILAS; }
        }

        public static int Columnas
        {
            get { return CANTIDAD_DE_COLUMNAS; }
        }

        /*Agrega una nave al tablero*/
        public void AgregarNave(Nave nave) 
        {
            naves.Add(nave);
        }

        /*Agrega un armamento al tablero*/
        public void Impactar(Armamento arma) 
        {
            if (!arma.Posicion.EstaDentroDe(Tablero.ESQUINA_IZQUIERDA_ARRIBA, Tablero.ESQUINA_DERECHA_ABAJO))
                throw new ArmamentoFueraDelTableroException();

            armamentos.Add(arma);
        }

        /*Obtiene las naves del tablero que estan en una posicion*/
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

        //---------------------------------------------------------------------

        /* Actualización del tablero.
         * Primero actualiza los armamentos, de forma de hacer que exploten si tienen que explotar,
         * Y luego mueve las naves */
        public void Actualizar() 
        {
            this.ActualizarArmamentos();
            this.BorrarArmamentosExplotados();
            this.ActualizarPosicionDeNaves();
        }

        /* Método auxiliar para mover las naves */
        private void ActualizarPosicionDeNaves()
        {
            foreach (Nave nave in naves)
            {
                nave.Mover();
            }
        }

        /* Método auxiliar para actualizar los armamentos */
        private void ActualizarArmamentos()
        {
            foreach (Armamento armamento in armamentos)
            {
                armamento.Actualizar();
            }
        }

        /* Método auxiliar para borrar los armamentos que ya están explotados y no sirven */
        private void BorrarArmamentosExplotados()
        {
            List<Armamento> armamentosActualizados = new List<Armamento>();
            foreach (Armamento armamento in armamentos)
            {
                if (!armamento.Explotado)
                {
                    armamentosActualizados.Add(armamento);
                }
            }
            this.armamentos = armamentosActualizados;
        }

        //---------------------------------------------------------------------
        /*Si el tablero sigue teniendo alguna nave*/
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

        /*Estado de las naves del tablero*/
        public Boolean TieneNavesConVida()
        {
            foreach (Nave nave in naves)
            {
                if (!nave.EstaDestruida())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
