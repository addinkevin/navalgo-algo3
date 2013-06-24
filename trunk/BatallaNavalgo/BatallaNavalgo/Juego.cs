﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgoExcepciones;

namespace BatallaNavalgo
{
    public class Juego : Observable
    {
        private Jugador jugador;
        private Tablero tablero;
        private List<Observador> observadores;

        /* Constructor
         * jugador: sera el jugador que este jugando BatallaNavalgo.
         * tablero: sera el tablero asociado al juego.
         */
        public Juego()
        {
            this.observadores = new List<Observador>();
        }

        /*Inicializa el Juego en un estado valido*/
        public void Inicializar()
        {
            this.tablero = new Tablero();
            AgregarNavesAlTablero(tablero);
            this.jugador = new Jugador();
        }

        /*Agrega observadores del juego*/
        public void AddObservador(Observador observador)
        {
            observadores.Add(observador);
        }

        /*Notifica actualizaciones a los observadores*/
        public void NotificarObservadores()
        {
            foreach (Observador observador in observadores)
            {
                observador.Update();
            }
        }

        /*Notifica creacion de lancha a los observadores*/
        public void NotificarObservadoresDeCreacionDeLancha(Nave nave)
        {
            foreach (Observador observador in observadores)
            {
                observador.NotificarCreacionDeLancha(nave);
            }
        }

        /*Notifica creacion de destructor a los observadores*/
        public void NotificarObservadoresDeCreacionDeDestructor(Nave nave)
        {
            foreach (Observador observador in observadores)
            {
                observador.NotificarCreacionDeDestructor(nave);
            }
        }

        /*Notifica creacion de portaaviones a los observadores*/
        public void NotificarObservadoresDeCreacionDePortaAviones(Nave nave)
        {
            foreach (Observador observador in observadores)
            {
                observador.NotificarCreacionDePortaAviones(nave);
            }
        }

        /*Notifica creacion de rompehielo a los observadores*/
        public void NotificarObservadoresDeCreacionDeRompeHielo(Nave nave)
        {
            foreach (Observador observador in observadores)
            {
                observador.NotificarCreacionDeRompeHielo(nave);
            }
        }

        /*Notifica creacion de buque a los observadores*/
        public void NotificarObservadoresDeCreacionDeBuque(Nave nave)
        {
            foreach (Observador observador in observadores)
            {
                observador.NotificarCreacionDeBuque(nave);
            }
        }

        //---------------------------------------------------------------------
        /*Devuelve un iterador de las naves del juego*/
        public List<Nave>.Enumerator IteradorNaves() 
        {
            return tablero.DevolverIteradorNaves();
        }

        /*Devuelve un iterador de los armamentos del juego*/
        public List<Armamento>.Enumerator IteradorArmamentos()
        {
            return tablero.DevolverIteradorArmamentos();
        }

        /*Avanza al proximo turno*/
        public void AvanzarTurno()
        {
            jugador.DescontarPuntosPorPasoDeTurno();
            tablero.Actualizar();
            NotificarObservadores();
        }
        //---------------------------------------------------------------------

        /* Auxiliar por el momento para probar la vista */
        private void AAgregarNavesAlTablero(Tablero tablero)
        {
            Nave lancha = new Nave(3, 1, new Posicion(1, 1), Orientacion.Horizontal);
            lancha.Direccion = Direccion.Oeste;
            NotificarObservadoresDeCreacionDeLancha(lancha);
            tablero.AgregarNave(lancha);

            Nave lancha2 = new Nave(3, 1, new Posicion(8, 10), Orientacion.Vertical);
            lancha2.Direccion = Direccion.Norte;
            NotificarObservadoresDeCreacionDeLancha(lancha2);
            tablero.AgregarNave(lancha2);
            
            Nave destructor = new Destructor(new Posicion(5, 5), Orientacion.Horizontal);
            destructor.Direccion = Direccion.Este;
            NotificarObservadoresDeCreacionDeDestructor(destructor);
            tablero.AgregarNave(destructor);

            Nave destructor2 = new Destructor(new Posicion(3, 5), Orientacion.Horizontal);
            destructor2.Direccion = Direccion.Este;
            NotificarObservadoresDeCreacionDeDestructor(destructor2);
            tablero.AgregarNave(destructor2);

            Nave destructor3 = new Destructor(new Posicion(7, 5), Orientacion.Horizontal);
            destructor3.Direccion = Direccion.Este;
            NotificarObservadoresDeCreacionDeDestructor(destructor3);
            tablero.AgregarNave(destructor3);

            Nave destructor4 = new Destructor(new Posicion(9, 5), Orientacion.Horizontal);
            destructor4.Direccion = Direccion.Este;
            NotificarObservadoresDeCreacionDeDestructor(destructor4);
            tablero.AgregarNave(destructor4);

        }

        /*Agregado de Naves al Tablero con: Posicion, Direccion y Orientacion aleatoria*/
        private void AgregarNavesAlTablero(Tablero tablero)
        {
            Nave lancha = NaveFactory.CrearLancha();
            NotificarObservadoresDeCreacionDeLancha(lancha);
            tablero.AgregarNave(lancha);

            Nave lancha2 = NaveFactory.CrearLancha();
            NotificarObservadoresDeCreacionDeLancha(lancha2);
            tablero.AgregarNave(lancha2);

            Nave destructor = NaveFactory.CrearDestructor();
            NotificarObservadoresDeCreacionDeDestructor(destructor);
            tablero.AgregarNave(destructor);
            
            Nave destructor2 = NaveFactory.CrearDestructor();
            NotificarObservadoresDeCreacionDeDestructor(destructor2);
            tablero.AgregarNave(destructor2);

            Nave rompeHielos = NaveFactory.CrearRompeHielos();
            NotificarObservadoresDeCreacionDeRompeHielo(rompeHielos);
            tablero.AgregarNave(rompeHielos);

            Nave buque = NaveFactory.CrearBuque();
            NotificarObservadoresDeCreacionDeBuque(buque);
            tablero.AgregarNave(buque);

            Nave portaAviones = NaveFactory.CrearPortaAviones();
            NotificarObservadoresDeCreacionDePortaAviones(portaAviones);
            tablero.AgregarNave(portaAviones);
        }
        //---------------------------------------------------------------------
        /*Devuelve los puntos actuales del jugador*/
        public int ObtenerPuntosDelJugador()
        {
            return jugador.Puntos;
        }

        /*Se efectua un DisparoComun en el tablero*/
        public void EfectuarDisparoComun(Posicion posicion)
        {
            DisparoComun disparo = ArmamentoFactory.CrearDisparoComun(this.tablero, posicion);
            VerificarPosibilidadDeDisparo(disparo);
            tablero.Impactar(disparo);
            jugador.DescontarPuntosPorDisparar(disparo);
            AvanzarTurno();
        }

        /*Se coloca una mina puntual en el tablero*/
        public void ColocarMinaPuntual(Posicion posicion)
        {
            MinaConRetardo minaPuntual = ArmamentoFactory.CrearMinaPuntual(this.tablero, posicion);
            VerificarPosibilidadDeDisparo(minaPuntual);
            tablero.Impactar(minaPuntual);
            jugador.DescontarPuntosPorDisparar(minaPuntual);
            AvanzarTurno();
        }

        /*Se coloca una mina doble en el tablero*/
        public void ColocarMinaDoble(Posicion posicion)
        {
            MinaConRetardo minaDoble = ArmamentoFactory.CrearMinaDoble(this.tablero, posicion);
            VerificarPosibilidadDeDisparo(minaDoble);
            tablero.Impactar(minaDoble);
            jugador.DescontarPuntosPorDisparar(minaDoble);
            AvanzarTurno();
        }

        /*Se coloca una mina triple en el tablero*/
        public void ColocarMinaTriple(Posicion posicion)
        {
            MinaConRetardo minaTriple = ArmamentoFactory.CrearMinaTriple(this.tablero, posicion);
            VerificarPosibilidadDeDisparo(minaTriple);
            tablero.Impactar(minaTriple);
            jugador.DescontarPuntosPorDisparar(minaTriple);
            AvanzarTurno();
        }

        /*Se coloca una mina por contacto en el tablero*/
        public void ColocarMinaPorContacto(Posicion posicion)
        {
            MinaPorContacto minaContacto = ArmamentoFactory.CrearMinaPorContacto(this.tablero, posicion);
            VerificarPosibilidadDeDisparo(minaContacto);
            tablero.Impactar(minaContacto);
            jugador.DescontarPuntosPorDisparar(minaContacto);
            AvanzarTurno();
        }

        /*Prueba que se pueda efectuar algun disparo posible*/
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

        /*Estado del juego*/
        public bool EstaTerminado()
        {
            bool jugadorTienePuntosParaJugar = jugador.TienePuntosParaJugar(CostoMinimoDeDisparo());
            bool hayNavesEnElTableroDeJuego = tablero.TieneNavesConVida();
            return !(jugadorTienePuntosParaJugar && hayNavesEnElTableroDeJuego);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");
            Console.ReadKey();
        }

        /*Estado del juego*/
        public Boolean Ganado()
        {
            if (tablero.TieneNavesConVida())
                return false;
            else
                return true;
        }
    }
}
