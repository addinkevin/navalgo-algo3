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
            this.jugador = new Jugador(tablero);
        }
        //---------------------------------------------------------------------

        private void AvanzarTurno()
        {
            jugador.DescontarPuntosPorPasoDeTurno();
            tablero.Actualizar();
        }
        //---------------------------------------------------------------------

        private void AgregarNavesAlTablero(Tablero tablero)
        {
            Posicion posicionAuxiliar = new Posicion(1,1);
            posicionAuxiliar.HacerAleatoria(Tablero.Filas, Tablero.Columnas);

            tablero.AgregarNave(NaveFactory.CrearLancha(posicionAuxiliar));

            posicionAuxiliar.HacerAleatoria(Tablero.Filas, Tablero.Columnas);
            tablero.AgregarNave(NaveFactory.CrearLancha(posicionAuxiliar));
            
            posicionAuxiliar.HacerAleatoria(Tablero.Filas, Tablero.Columnas);
            tablero.AgregarNave(NaveFactory.CrearDestructor(posicionAuxiliar));
            
            posicionAuxiliar.HacerAleatoria(Tablero.Filas, Tablero.Columnas);
            tablero.AgregarNave(NaveFactory.CrearDestructor(posicionAuxiliar));
            
            posicionAuxiliar.HacerAleatoria(Tablero.Filas, Tablero.Columnas);
            tablero.AgregarNave(NaveFactory.CrearRompeHielos(posicionAuxiliar));
            
            posicionAuxiliar.HacerAleatoria(Tablero.Filas, Tablero.Columnas);
            tablero.AgregarNave(NaveFactory.CrearBuque(posicionAuxiliar));
            
            posicionAuxiliar.HacerAleatoria(Tablero.Filas, Tablero.Columnas);
            tablero.AgregarNave(NaveFactory.CrearPortaAviones(posicionAuxiliar));
        }
        //---------------------------------------------------------------------

        public void EfectuarDisparoComun(Posicion posicion)
        {
            DisparoComun disparo = ArmamentoFactory.CrearDisparoComun(posicion);
            jugador.Disparar(disparo);
            AvanzarTurno();
        }

        public void ColocarMinaPuntual(Posicion posicion)
        {
            MinaConRetardo minaPuntual = ArmamentoFactory.CrearMinaPuntual(posicion);
            jugador.Disparar(minaPuntual);
            AvanzarTurno();
        }

        public void ColocarMinaDoble(Posicion posicion)
        {
            MinaConRetardo minaDoble = ArmamentoFactory.CrearMinaDoble(posicion);
            jugador.Disparar(minaDoble);
            AvanzarTurno();
        }

        public void ColocarMinaTriple(Posicion posicion)
        {
            MinaConRetardo minaTriple = ArmamentoFactory.CrearMinaTriple(posicion);
            jugador.Disparar(minaTriple);
            AvanzarTurno();
        }

        public void ColocarMinaPorContacto(Posicion posicion)
        {
            MinaPorContacto minaContacto = ArmamentoFactory.CrearMinaPorContacto(posicion);
            jugador.Disparar(minaContacto);
            AvanzarTurno();
        }
        //---------------------------------------------------------------------

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");            
        }
    }
}