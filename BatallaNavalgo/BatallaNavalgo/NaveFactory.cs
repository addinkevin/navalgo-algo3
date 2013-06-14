using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class NaveFactory
    {
        public static Direccion[] direcciones = new Direccion[] {
            new Direccion(0,1), new Direccion(1,0), new Direccion(1,1),
            new Direccion(-1,0), new Direccion(0,-1), new Direccion(-1,-1) };

        private static Direccion ObtenerDireccionAleatoria()
        {
            int numeroDeDireccionAleatoria = (new Random()).Next(0, NaveFactory.direcciones.Length);

            return NaveFactory.direcciones[numeroDeDireccionAleatoria];
        }

        public static int ObtenerCeroOUnoAlAzar()
        {
            return (new Random()).Next(0, 2);
        }

        public static Nave CrearLancha(Posicion posicion)
        {
            int orientacionNave = ObtenerCeroOUnoAlAzar();
            Nave lancha = new Nave(2, 1, posicion, orientacionNave);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            lancha.Direccion = direccionDeNave;
            return lancha;
        }

        public static Destructor CrearDestructor(Posicion posicion)
        {
            int orientacionNave = ObtenerCeroOUnoAlAzar();
            Destructor destructor = new Destructor(posicion, orientacionNave);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            destructor.Direccion = direccionDeNave;
            return destructor;
        }

        public static Nave CrearPortaAviones(Posicion posicion)
        {
            int orientacionNave = ObtenerCeroOUnoAlAzar();
            Nave portaAviones = new Nave(5, 1, posicion, orientacionNave);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            portaAviones.Direccion = direccionDeNave;
            return portaAviones;
        }

        public static Nave CrearRompeHielos(Posicion posicion)
        {
            int orientacionNave = ObtenerCeroOUnoAlAzar();
            Nave rompeHielos = new Nave(3, 2, posicion, orientacionNave);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            rompeHielos.Direccion = direccionDeNave;
            return rompeHielos;
        }

        public static Buque CrearBuque(Posicion posicion)
        {
            int orientacionNave = ObtenerCeroOUnoAlAzar();
            Buque buque = new Buque(posicion, orientacionNave);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            buque.Direccion = direccionDeNave;
            return buque;
        }
    }
}