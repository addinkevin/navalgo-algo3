using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class NaveFactory
    {
        public static Random numeroAleatorio = new Random();

        /*Se obtiene una direccion aleatoria dentro de las posibles direcciones que existen*/
        private static Direccion ObtenerDireccionAleatoria()
        {
            int numeroDeDireccionAleatoria = (numeroAleatorio).Next(0, Direccion.DireccionesDisponibles.Length);

            return Direccion.DireccionesDisponibles[numeroDeDireccionAleatoria];
        }

        /*Se obtiene una orientacion aleatoria dentro de las posibles orientaciones que existen*/
        public static Orientacion ObtenerOrientacionAleatoria()
        {
            if ((numeroAleatorio).Next(0, 2) == 0)
                return Orientacion.Vertical;
            return Orientacion.Horizontal;
        }

        /*Se obtiene una posicion aleatoria dentro de las posibles posiciones que existen*/
        public static Posicion ObtenerPosicionAleatoria()
        {
            return Posicion.HacerAleatoria(1, Tablero.Filas, 1, Tablero.Columnas);
        }

        /*Crea una lancha con posicion, direccion y orientacion aleatoria*/
        public static Nave CrearLancha()
        {
            int numeroDePartesLancha = 2;
            int resistenciaDeLancha = 1;
            Posicion posicionAleatoria;
            Orientacion orientacionNave;
            do
            {
                posicionAleatoria = ObtenerPosicionAleatoria();
                orientacionNave = ObtenerOrientacionAleatoria();               
            } while (!Nave.SePuedeCrear(numeroDePartesLancha, posicionAleatoria, orientacionNave));

            Direccion direccionDeNave = ObtenerDireccionAleatoria();            
            Nave lancha = new Nave(numeroDePartesLancha, resistenciaDeLancha, posicionAleatoria, orientacionNave, direccionDeNave);
            
            return lancha;
        }

        /*Crea un destructor con posicion, direccion y orientacion aleatoria*/
        public static Destructor CrearDestructor()
        {
            Posicion posicionAleatoria;
            Orientacion orientacionNave;
            do
            {
                posicionAleatoria = ObtenerPosicionAleatoria();
                orientacionNave = ObtenerOrientacionAleatoria();
            } while (!Destructor.SePuedeCrear(posicionAleatoria, orientacionNave));

            Direccion direccionDeNave = ObtenerDireccionAleatoria();            
            Destructor destructor = new Destructor(posicionAleatoria, orientacionNave,direccionDeNave);
            
            return destructor;
        }

        /*Crea un PortaAviones con posicion, direccion y orientacion aleatoria*/
        public static Nave CrearPortaAviones()
        {
            int numeroDePartesPortaAviones = 5;
            int resistenciaDePartesPortaAviones = 1;

            Orientacion orientacionNave;
            Posicion posicionAleatoria;
            do
            {
                orientacionNave = ObtenerOrientacionAleatoria();
                posicionAleatoria = ObtenerPosicionAleatoria();
            } while (!Nave.SePuedeCrear(numeroDePartesPortaAviones, posicionAleatoria, orientacionNave));

            Direccion direccionDeNave = ObtenerDireccionAleatoria();            
            Nave portaAviones = new Nave(numeroDePartesPortaAviones, resistenciaDePartesPortaAviones, posicionAleatoria, orientacionNave, direccionDeNave);
           
            return portaAviones;
        }
        
        /*Crea un RompeHielos con posicion, direccion y orientacion aleatoria*/
        public static Nave CrearRompeHielos()
        {
            int numeroDePartesRompeHielo = 3;
            int resistenciaDePartesRompeHielo = 2;
            Orientacion orientacionNave;
            Posicion posicionAleatoria;
            do
            {
                orientacionNave = ObtenerOrientacionAleatoria();
                posicionAleatoria = ObtenerPosicionAleatoria();
            } while (!Nave.SePuedeCrear(numeroDePartesRompeHielo, posicionAleatoria, orientacionNave));

            Direccion direccionDeNave = ObtenerDireccionAleatoria();            
            Nave rompeHielos = new Nave(numeroDePartesRompeHielo, resistenciaDePartesRompeHielo, posicionAleatoria, orientacionNave,direccionDeNave);
            
            return rompeHielos;
        }

        /*Crea un Buque con posicion, direccion y orientacion aleatoria*/
        public static Buque CrearBuque()
        {
            Posicion posicionAleatoria;
            Orientacion orientacionNave;
            do
            {
                posicionAleatoria = ObtenerPosicionAleatoria();
                orientacionNave = ObtenerOrientacionAleatoria();
            } while (!Buque.SePuedeCrear(posicionAleatoria, orientacionNave));

            Direccion direccionDeNave = ObtenerDireccionAleatoria();            
            Buque buque = new Buque(posicionAleatoria, orientacionNave,direccionDeNave);
            
            return buque;
        }
    }
}