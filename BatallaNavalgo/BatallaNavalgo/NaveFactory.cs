using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatallaNavalgo
{
    public class NaveFactory
    {
        private static int ObtenerCeroOUnoAlAzar() 
        {
            Random orientar = new Random();    
            /*El 2 no se incluye en el intervalo */
            int OrientacionNave = orientar.Next(0, 2);
            return OrientacionNave;        
        }
       

        private static Direccion ObtenerDireccionAleatoria() 
        {
            /*La convencion es arbitraria, pero por precondicion los
             movimientos solo pueden ser +1 o -1 */
            int MovimientoEnFilas, MovimientoEnColumnas;            
            if (ObtenerCeroOUnoAlAzar() == 0) 
            { MovimientoEnFilas= 1;}
            else
            {MovimientoEnFilas=-1;}

            if (ObtenerCeroOUnoAlAzar() == 0)
            { MovimientoEnColumnas = 1; }
            else
            { MovimientoEnColumnas = -1; }
            Direccion direccion = new Direccion(MovimientoEnFilas, MovimientoEnColumnas);

            return direccion;
        }

        public static Nave CrearLancha (Posicion posicion, int orientacion)
        {
            Nave lancha = new Nave(2, 1, posicion, orientacion);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            lancha.SetDireccion(direccionDeNave);
            return lancha;               
        }

        public static Destructor CrearDestructor(Posicion posicion, int orientacion)
        {
            Destructor destructor = new Destructor(posicion, orientacion);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            destructor.SetDireccion(direccionDeNave);
            return destructor;
        }

        public static Nave CrearPortaAviones(Posicion posicion, int orientacion)
        {
            Nave portaAviones = new Nave(5, 1, posicion, orientacion);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            portaAviones.SetDireccion(direccionDeNave);
            return portaAviones;  
        }

        public static Nave CrearRomeHielos(Posicion posicion, int orientacion) 
        {
            Nave rompeHielos = new Nave(3, 2, posicion, orientacion);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            rompeHielos.SetDireccion(direccionDeNave);
            return rompeHielos;          
        }

        public static Buque CrearBuque(Posicion posicion, int orientacion)
        {
            Buque buque = new Buque(posicion, orientacion);
            Direccion direccionDeNave = ObtenerDireccionAleatoria();
            buque.SetDireccion(direccionDeNave);
            return buque;
        }

    }
}
