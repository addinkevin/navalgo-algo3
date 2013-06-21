﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        
        public Tablero()
        {            
            armamentos = new List<Armamento>();
            naves = new List<Nave>();
        }

        public List<Nave>.Enumerator DevolverIteradorNaves() 
        {
            return naves.GetEnumerator();            
        }

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


        public void AgregarNave(Nave nave) 
        {
            naves.Add(nave);
        }

        public void Impactar(Armamento arma) 
        {
            armamentos.Add(arma);
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
                Posicion posicionMina = mina.Posicion;
                if (posicion.EsIgualA(posicionMina))
                {
                    return true;
                }
            }
            return false;
        }

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
