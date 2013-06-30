using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;

namespace BatallaNavalgoTests
{
    public class ObservadorParaPruebaDeIntegracion: IObservador
    {
        List<Nave> navesLancha;
        List<Destructor> navesDestructor;
        List<Nave> navesPortaAviones;
        List<Buque> navesBuque;
        List<Nave> navesRompeHielo;
        List<MinaConRetardo> minasConRetardo;
        List<MinaPorContacto> minasPorContacto;

        public ObservadorParaPruebaDeIntegracion()
        {
            navesLancha = new List<Nave>();
            navesDestructor = new List<Destructor>();
            navesPortaAviones = new List<Nave>();
            navesBuque = new List<Buque>();
            navesRompeHielo = new List<Nave>();
            minasConRetardo = new List<MinaConRetardo>();
            minasPorContacto = new List<MinaPorContacto>();

        }
        public List<Nave> NavesLancha
        {
            get { return navesLancha; }
        }
        public List<Nave> NavesPortaAviones
        {
            get { return navesPortaAviones; }
        }
        public List<Nave> NavesRompeHielo
        {
            get { return navesRompeHielo; }
        }
        public List<Destructor> NavesDestructores
        {
            get { return navesDestructor; }
        }
        public List<Buque> NavesBuque
        {
            get { return navesBuque; }
        }

        public void NotificarCreacionDeLancha(Nave nave)
        {
            navesLancha.Add(nave);
        }
        public void NotificarCreacionDeDestructor(Destructor nave)
        {
            navesDestructor.Add(nave);
        }
        public void NotificarCreacionDePortaAviones(Nave nave)
        {
            navesPortaAviones.Add(nave);
        }
        public void NotificarCreacionDeRompeHielo(Nave nave)
        {
            navesRompeHielo.Add(nave);
        }
        public void NotificarCreacionDeBuque(Buque nave)
        {
            navesBuque.Add(nave);
        }
        public void NotificarCreacionDeMinaConRetardo(MinaConRetardo mina)
        {
            minasConRetardo.Add(mina);
        }

        public void NotificarCreacionDeMinaPorContacto(MinaPorContacto mina)
        {
            minasPorContacto.Add(mina);
        }

    }
}
