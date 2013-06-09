using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class BatallaNavalgo
    {
        private Jugador jugador;
        private Tablero tablero;

        /* Constructor
         * jugador: sera el jugador que este jugando BatallaNavalgo.
         * tablero: sera el tablero asociado al juego.
         */
        public BatallaNavalgo()
        {
            this.tablero = new Tablero();
            //Hay que agregar el tema para agregar naves en el tablero de manera aleatoria.
            //Forma aleatoria -> tablero.AgregarNave(nave).
            this.jugador = new Jugador(tablero);
        }
        //---------------------------------------------------------------------

        public void AvanzarTurno()
        {
            jugador.DescontarPuntosPorPasoDeTurno();
            tablero.Actualizar();
        }

        public void EfectuarDisparoComun(Posicion posicion)
        {
            DisparoComun disparo = ArmamentoFactory.CrearDisparoComun(posicion);
            jugador.Disparar(disparo);
        }

        public void ColocarMinaPuntual(Posicion posicion)
        {
            MinaConRetardo minaPuntual = ArmamentoFactory.CrearMinaPuntual(posicion);
            jugador.Disparar(minaPuntual);
        }

        public void ColocarMinaDoble(Posicion posicion)
        {
            MinaConRetardo minaDoble = ArmamentoFactory.CrearMinaDoble(posicion);
            jugador.Disparar(minaDoble);
        }

        public void ColocarMinaTriple(Posicion posicion)
        {
            MinaConRetardo minaTriple = ArmamentoFactory.CrearMinaTriple(posicion);
            jugador.Disparar(minaTriple);
        }

        public void ColocarMinaPorContacto(Posicion posicion)
        {
            MinaPorContacto minaContacto = ArmamentoFactory.CrearMinaPorContacto(posicion);
            jugador.Disparar(minaContacto);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");
        }
    }
}
