﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgoExcepciones;

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

        public List<Nave>.Enumerator IteradorNaves() 
        {
            return tablero.DevolverIteradorNaves();
        }


        public void AvanzarTurno()
        {
            jugador.DescontarPuntosPorPasoDeTurno();
            tablero.Actualizar();
        }
        //---------------------------------------------------------------------

       
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
            VerificarPosibilidadDeDisparo(disparo);
            tablero.Impactar(disparo);
            jugador.DescontarPuntosPorDisparar(disparo);
            AvanzarTurno();
        }

        public void ColocarMinaPuntual(Posicion posicion)
        {
            MinaConRetardo minaPuntual = ArmamentoFactory.CrearMinaPuntual(this.tablero, posicion);
            VerificarPosibilidadDeDisparo(minaPuntual);
            tablero.Impactar(minaPuntual);
            jugador.DescontarPuntosPorDisparar(minaPuntual);
            AvanzarTurno();
        }

        public void ColocarMinaDoble(Posicion posicion)
        {
            MinaConRetardo minaDoble = ArmamentoFactory.CrearMinaDoble(this.tablero, posicion);
            VerificarPosibilidadDeDisparo(minaDoble);
            tablero.Impactar(minaDoble);
            jugador.DescontarPuntosPorDisparar(minaDoble);
            AvanzarTurno();
        }

        public void ColocarMinaTriple(Posicion posicion)
        {
            MinaConRetardo minaTriple = ArmamentoFactory.CrearMinaTriple(this.tablero, posicion);
            VerificarPosibilidadDeDisparo(minaTriple);
            tablero.Impactar(minaTriple);
            jugador.DescontarPuntosPorDisparar(minaTriple);
            AvanzarTurno();
        }

        public void ColocarMinaPorContacto(Posicion posicion)
        {
            MinaPorContacto minaContacto = ArmamentoFactory.CrearMinaPorContacto(this.tablero, posicion);
            VerificarPosibilidadDeDisparo(minaContacto);
            tablero.Impactar(minaContacto);
            jugador.DescontarPuntosPorDisparar(minaContacto);
            AvanzarTurno();
        }

        private void VerificarPosibilidadDeDisparo(Armamento armamento)
        {
            if (EstaTerminado())
                throw new JuegoTerminadoException();

            if (!jugador.TienePuntosParaJugar(armamento.Costo))
                throw new JuegoJugadorSinPuntajeParaDisparoException();
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

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");
        }
    }
}