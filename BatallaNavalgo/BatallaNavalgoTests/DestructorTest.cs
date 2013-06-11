﻿using System;
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
            Destructor destructor = new Destructor( new Posicion(3,3), Nave.VERTICAL);
            Mina mina1 = ArmamentoFactory.CrearMinaPorContacto(new Posicion(3, 3));
            Mina mina2 = ArmamentoFactory.CrearMinaPorContacto(new Posicion(4, 3));
            Mina mina3 = ArmamentoFactory.CrearMinaPorContacto(new Posicion(5, 3));
            destructor.RecibirAtaque(mina1, mina1.GetPosicion());
            destructor.RecibirAtaque(mina2, mina2.GetPosicion());
            destructor.RecibirAtaque(mina3, mina3.GetPosicion());

            Assert.False(destructor.EstaDestruida());
        }

        [Test]
        public void testDeberiaDestruirloSiLoAtacoConDisparosComunes()
        {
            Destructor destructor = new Destructor(new Posicion(3, 3), Nave.VERTICAL);
            DisparoComun disparo1 = ArmamentoFactory.CrearDisparoComun(new Posicion(3, 3));
            DisparoComun disparo2 = ArmamentoFactory.CrearDisparoComun(new Posicion(4, 3));
            DisparoComun disparo3 = ArmamentoFactory.CrearDisparoComun(new Posicion(5, 3));

            destructor.RecibirAtaque(disparo1, disparo1.GetPosicion());
            destructor.RecibirAtaque(disparo2, disparo2.GetPosicion());
            destructor.RecibirAtaque(disparo3, disparo3.GetPosicion());

            Assert.True(destructor.EstaDestruida());
        }



    }
}