using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class NaveFactory
    {
        private static Direccion ObtenerDireccionAleatoria()
        {
            int numeroDeDireccionAleatoria = (new Random()).Next(0, Direccion.DireccionesDisponibles.Length);

            return Direccion.DireccionesDisponibles[numeroDeDireccionAleatoria];
        }

        public static Orientacion ObtenerOrientacionAleatoria(int semilla)
        {
            Random numeroAleatorio = new Random(semilla);
            int resultado = numeroAleatorio.Next(1,101);
            if (resultado <=50)
                return Orientacion.Horizontal;
            else
                return Orientacion.Vertical;
        }

        public static Posicion ObtenerPosicionAleatoria()
        {
            return Posicion.HacerAleatoria(1, Tablero.Filas, 1, Tablero.Columnas);
        }

        public static Nave CrearLancha(int semilla)
        {
            int numeroDePartesLancha = 2;
            int resistenciaDeLancha = 1;
            Posicion posicionAleatoria;
            Orientacion orientacionNave;
            do
            {
                posicionAleatoria = ObtenerPosicionAleatoria();
                orientacionNave = ObtenerOrientacionAleatoria(semilla);               
            } while (!Nave.SePuedeCrear(numeroDePartesLancha, posicionAleatoria, orientacionNave));

            Nave lancha = new Nave(numeroDePartesLancha, resistenciaDeLancha, posicionAleatoria, orientacionNave);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            lancha.Direccion = direccionDeNave;
            return lancha;
        }

        public static Destructor CrearDestructor(int semilla)
        {
            Posicion posicionAleatoria;
            Orientacion orientacionNave;
            do
            {
                posicionAleatoria = ObtenerPosicionAleatoria();
                orientacionNave = ObtenerOrientacionAleatoria(semilla);
            } while (!Destructor.SePuedeCrear(posicionAleatoria, orientacionNave));

            Destructor destructor = new Destructor(posicionAleatoria, orientacionNave);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            destructor.Direccion = direccionDeNave;
            return destructor;
        }

        public static Nave CrearPortaAviones(int semilla)
        {
            int numeroDePartesPortaAviones = 5;
            int resistenciaDePartesPortaAviones = 1;

            Orientacion orientacionNave;
            Posicion posicionAleatoria;
            do
            {
                orientacionNave = ObtenerOrientacionAleatoria(semilla);
                posicionAleatoria = ObtenerPosicionAleatoria();
            } while (!Nave.SePuedeCrear(numeroDePartesPortaAviones, posicionAleatoria, orientacionNave));
            
            Nave portaAviones = new Nave(numeroDePartesPortaAviones, resistenciaDePartesPortaAviones, posicionAleatoria, orientacionNave);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            portaAviones.Direccion = direccionDeNave;
            return portaAviones;
        }

        public static Nave CrearRompeHielos(int semilla)
        {
            int numeroDePartesRompeHielo = 3;
            int resistenciaDePartesRompeHielo = 2;
            Orientacion orientacionNave;
            Posicion posicionAleatoria;
            do
            {
                orientacionNave = ObtenerOrientacionAleatoria(semilla);
                posicionAleatoria = ObtenerPosicionAleatoria();
            } while (!Nave.SePuedeCrear(numeroDePartesRompeHielo, posicionAleatoria, orientacionNave));

            Nave rompeHielos = new Nave(numeroDePartesRompeHielo, resistenciaDePartesRompeHielo, posicionAleatoria, orientacionNave);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            rompeHielos.Direccion = direccionDeNave;
            return rompeHielos;
        }

        public static Buque CrearBuque(int semilla)
        {
            Posicion posicionAleatoria;
            Orientacion orientacionNave;
            do
            {
                posicionAleatoria = ObtenerPosicionAleatoria();
                orientacionNave = ObtenerOrientacionAleatoria(semilla);
            } while (!Buque.SePuedeCrear(posicionAleatoria, orientacionNave));

            Buque buque = new Buque(posicionAleatoria, orientacionNave);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            buque.Direccion = direccionDeNave;
            return buque;
        }
    }
}