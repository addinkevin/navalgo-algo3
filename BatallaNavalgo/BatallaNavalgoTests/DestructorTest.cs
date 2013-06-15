using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BatallaNavalgo;

namespace BatallaNavalgoTests
{
    [TestFixture]
    class DestructorTest
    {
        [Test]
        public void testNoDeberiaDestruirloSiLoAtacoConMinas()
        {
            Destructor destructor = new Destructor( new Posicion(3,3), Orientacion.Vertical);
            Mina mina1 = ArmamentoFactory.CrearMinaPorContacto(new Tablero(), new Posicion(3, 3));
            Mina mina2 = ArmamentoFactory.CrearMinaPorContacto(new Tablero(), new Posicion(4, 3));
            Mina mina3 = ArmamentoFactory.CrearMinaPorContacto(new Tablero(), new Posicion(5, 3));
            destructor.RecibirAtaque(mina1, mina1.Posicion);
            destructor.RecibirAtaque(mina2, mina2.Posicion);
            destructor.RecibirAtaque(mina3, mina3.Posicion);

            Assert.False(destructor.EstaDestruida());
        }

        [Test]
        public void testDeberiaDestruirloSiLoAtacoConDisparosComunes()
        {
            Destructor destructor = new Destructor(new Posicion(3, 3), Orientacion.Vertical);
            DisparoComun disparo1 = ArmamentoFactory.CrearDisparoComun(new Tablero(), new Posicion(3, 3));
            DisparoComun disparo2 = ArmamentoFactory.CrearDisparoComun(new Tablero(), new Posicion(4, 3));
            DisparoComun disparo3 = ArmamentoFactory.CrearDisparoComun(new Tablero(), new Posicion(5, 3));

            destructor.RecibirAtaque(disparo1, disparo1.Posicion);
            destructor.RecibirAtaque(disparo2, disparo2.Posicion);
            destructor.RecibirAtaque(disparo3, disparo3.Posicion);

            Assert.True(destructor.EstaDestruida());
        }



    }
}
