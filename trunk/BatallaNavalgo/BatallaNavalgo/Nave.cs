using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgoExcepciones;

namespace BatallaNavalgo
{
    public enum Orientacion
    {
        Vertical = 0,
        Horizontal = 1
    }

    public class Nave: IAtacable
    {
        private Direccion direccion;
        private List<ParteNave> partes;

        /* Constructor
         * resistenciaDePartes: numero de golpes necesarios para destruir la parte
         * posicionInicial: Posicion donde arranca la nave.
         * orientacion = HORIZONTAL : Crea la nave desde la posicion inicial hacia la derecha ( suma de columna)
         * orientacion = VERTICAL : Crea la nave desde la posicion inicial hacia abajo ( suma de filas )
         */
        public Nave(int numeroDePartes, int resistenciaDePartes, Posicion posicionInicial, Orientacion orientacion)
        {
            this.CrearPartes(numeroDePartes, resistenciaDePartes, posicionInicial, orientacion);            
        }

        public Direccion Direccion 
        {
            set { direccion = value; }
        }
               
        private List<Posicion> GetPosicionesParaCrearNave(int numeroDePartes, Posicion posicionInicial, Orientacion orientacion)
        {
            List<Posicion> posiciones = new List<Posicion>();
            posiciones.Add(posicionInicial);
            Posicion posicion = posicionInicial;
            for (int i = 0; i < numeroDePartes - 1; i++)
            {
                if (orientacion == Orientacion.Vertical)
                {
                    posicion = new Posicion(posicion.Fila + 1, posicion.Columna);
                }
                else
                {
                    posicion = new Posicion(posicion.Fila, posicion.Columna + 1);
                }
                posiciones.Add(posicion);
            }
            return posiciones;
        }

        /* Permite crear todas las partes de las naves.
         * orientacion = HORIZONTAL : Crea la nave desde la posicion inicial hacia la derecha ( suma de columna)
         * orientacion = VERTICAL : Crea la nave desde la posicion inicial hacia abajo ( suma de filas )
         */
        private void CrearPartes(int numeroDePartes, int resistencia, Posicion posicionInicial, Orientacion orientacion)
        {
            this.partes = new List<ParteNave>();
            List<Posicion> posiciones = GetPosicionesParaCrearNave(numeroDePartes, posicionInicial, orientacion);
            foreach (Posicion posicion in posiciones)
            {
                if (!posicion.EstaDentroDe(Tablero.ESQUINA_IZQUIERDA_ARRIBA, Tablero.ESQUINA_DERECHA_ABAJO))
                {
                    throw new ImposibleCrearNaveException();
                }

                this.partes.Add(new ParteNave(resistencia, posicion));
            }
        }

        /* Obtiene las posiciones donde se encuentra la nave */
        public List<Posicion> GetPosiciones()
        {
            List<Posicion> lista = new List<Posicion>();
            foreach ( ParteNave parte in partes)
            {
                lista.Add(parte.Posicion);
            }
            return lista;
        }



        /* Permite verificar si la nave esta destruida en su totalidad */
        public virtual Boolean EstaDestruida() 
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
        
        /* Permite atacar a la nave, en la posicion especificada*/
        private void RecibirAtaqueGeneral(Armamento armamento, Posicion posicion)
        {
            foreach (ParteNave parte in partes)
            {
                if (parte.Posicion.EsIgualA(posicion))
                {
                    parte.RecibirAtaque();
                    return;
                }

            }
        }

        /* Ataca a la nave, dado un disparo */
        public virtual void RecibirAtaque(DisparoComun disparo, Posicion posicion)
        {
            RecibirAtaqueGeneral(disparo, posicion);
        }

        /* Ataca a la nave, dada una mina */
        public virtual void RecibirAtaque(Mina mina, Posicion posicion)
        {
            RecibirAtaqueGeneral(mina, posicion);
        }

        /* Ataca la parte de la nave correspondiente a la posicion pasada */
        private void RecibirAtaqueEn(Posicion posicion)
        {
            foreach (ParteNave parte in partes)
            {
                if (parte.Posicion.EsIgualA(posicion))
                {
                    parte.RecibirAtaque();
                    return;
                }
            }            
        }

        /* Verifica que la nueva posicion de las partes este dentro del rango del Tablero */
        private Boolean SePuedenMoverLasPartes()
        {
            foreach (ParteNave parte in partes)
            {
                if (!direccion.GetNuevaPosicion(parte.Posicion).EstaDentroDe(Tablero.ESQUINA_IZQUIERDA_ARRIBA,
                                                                             Tablero.ESQUINA_DERECHA_ABAJO))
                    return false;
            }
            return true;
        }

        /* Mueve todas las posiciones de la nave, segun la direccion especificada */
        public void Mover ( )
        {
            if (!SePuedenMoverLasPartes())
            {
                direccion = direccion.Invertir();
            }

            foreach(ParteNave parte in partes)
            {
                parte.Posicion = direccion.GetNuevaPosicion(parte.Posicion);
            }
        }

        /* Permite saber si la parte ubicada en posicion está destruida o no */
        public bool EstaDestruidaEnLaPosicion(Posicion posicion)
        {
            foreach (ParteNave parte in partes)
            {
                if (parte.Posicion.EsIgualA(posicion))
                    return parte.EstaDestruida();
            }
            return false;
        }

        public static bool SePuedeCrear(int numeroDePartes, Posicion posicionInicial, Orientacion orientacion)
        {
            Posicion posicionExtrema;
            if (orientacion == Orientacion.Vertical)
                posicionExtrema = new Posicion(posicionInicial.Fila + numeroDePartes - 1, posicionInicial.Columna);
            else 
                posicionExtrema = new Posicion(posicionInicial.Fila, posicionInicial.Columna + numeroDePartes - 1);

            bool posicionInicialValida = posicionInicial.EstaDentroDe(Tablero.ESQUINA_IZQUIERDA_ARRIBA, Tablero.ESQUINA_DERECHA_ABAJO);
            bool posicionExtremaValida = posicionExtrema.EstaDentroDe(Tablero.ESQUINA_IZQUIERDA_ARRIBA, Tablero.ESQUINA_DERECHA_ABAJO);

            return posicionInicialValida && posicionExtremaValida;
        }
    }
}
