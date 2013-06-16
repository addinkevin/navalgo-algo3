﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class Juego
    {
        private Jugador jugador;
        private Tablero tablero;

        /* Constructor
         * jugador: sera el jugador que este jugando BatallaNavalgo.
         * tablero: sera el tablero asociado al juego.
         */
        public Juego()
        {
            this.tablero = new Tablero();

            /*Agregado de Naves al Tablero con: 
             * Posicion ya establecida.
             * Direccion y Orientacion aleatoria.
             */
            AgregarNavesAlTablero(tablero);
            this.jugador = new Jugador();
        }
        //---------------------------------------------------------------------

        public void AvanzarTurno()
        {
            jugador.DescontarPuntosPorPasoDeTurno();
            tablero.Actualizar();
        }
        //---------------------------------------------------------------------

        private void AgregarLanchas(Tablero tablero)
        {
            
        }

        private void AgregarNavesAlTablero(Tablero tablero)
        {

            tablero.AgregarNave(NaveFactory.CrearLancha());

            tablero.AgregarNave(NaveFactory.CrearLancha());
            
            tablero.AgregarNave(NaveFactory.CrearDestructor());
            
            tablero.AgregarNave(NaveFactory.CrearDestructor());
            
            tablero.AgregarNave(NaveFactory.CrearRompeHielos());
            
            tablero.AgregarNave(NaveFactory.CrearBuque());
            
            tablero.AgregarNave(NaveFactory.CrearPortaAviones());
        }
        //---------------------------------------------------------------------

        public int ObtenerPuntosDelJugador()
        {
            return jugador.Puntos;
        }

        public void EfectuarDisparoComun(Posicion posicion)
        {
            DisparoComun disparo = ArmamentoFactory.CrearDisparoComun(this.tablero, posicion);
            tablero.Impactar(disparo);
            jugador.DescontarPuntosPorDisparar(disparo);
            AvanzarTurno();
        }

        public void ColocarMinaPuntual(Posicion posicion)
        {
            MinaConRetardo minaPuntual = ArmamentoFactory.CrearMinaPuntual(this.tablero, posicion);
            tablero.Impactar(minaPuntual);
            jugador.DescontarPuntosPorDisparar(minaPuntual);
            AvanzarTurno();
        }

        public void ColocarMinaDoble(Posicion posicion)
        {
            MinaConRetardo minaDoble = ArmamentoFactory.CrearMinaDoble(this.tablero, posicion);
            tablero.Impactar(minaDoble);
            jugador.DescontarPuntosPorDisparar(minaDoble);
            AvanzarTurno();
        }

        public void ColocarMinaTriple(Posicion posicion)
        {
            MinaConRetardo minaTriple = ArmamentoFactory.CrearMinaTriple(this.tablero, posicion);
            tablero.Impactar(minaTriple);
            jugador.DescontarPuntosPorDisparar(minaTriple);
            AvanzarTurno();
        }

        public void ColocarMinaPorContacto(Posicion posicion)
        {
            MinaPorContacto minaContacto = ArmamentoFactory.CrearMinaPorContacto(this.tablero, posicion);
            tablero.Impactar(minaContacto);
            jugador.DescontarPuntosPorDisparar(minaContacto);
            AvanzarTurno();
        }
        //---------------------------------------------------------------------

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");            
        }

        private int CostoMinimoDeDisparo()
        {
            int[] costos = new int[] { ArmamentoFactory.COSTO_DISPARO_COMUN, ArmamentoFactory.COSTO_MINA_PUNTUAL,
                                       ArmamentoFactory.COSTO_MINA_DOBLE, ArmamentoFactory.COSTO_MINA_TRIPLE,
                                       ArmamentoFactory.COSTO_MINA_POR_CONTACTO };
            return costos.Min();
        }
        public bool EstaTerminado()
        {
            bool jugadorTienePuntosParaJugar = jugador.TienePuntosParaJugar(CostoMinimoDeDisparo());
            bool hayNavesEnElTableroDeJuego = tablero.TieneNavesConVida();
            return !(jugadorTienePuntosParaJugar && hayNavesEnElTableroDeJuego);
        }
    }
}
