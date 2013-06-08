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
       /* [Test]
        public void testNoDeberiaDestruirloSiLoAtacoConMinas()
        {
            Destructor destructor = new Destructor( new Posicion(3,3), Nave.VERTICAL);
            
            destructor.RecibirAtaque(new Mina(new Posicion(3,3)));
            destructor.RecibirAtaque(new Mina(new Posicion(4,3)));
            destructor.RecibirAtaque(new Mina(new Posicion(5,3)));

            Assert.False(destructor.EstaDestruida());
        }*/

        [Test]
        public void testDeberiaDestruirloSiLoAtacoConDisparosComunes()
        {
            Destructor destructor = new Destructor(new Posicion(3, 3), Nave.VERTICAL);

            destructor.RecibirAtaque(new DisparoComun(new Posicion(3, 3)));
            destructor.RecibirAtaque(new DisparoComun(new Posicion(4, 3)));
            destructor.RecibirAtaque(new DisparoComun(new Posicion(5, 3)));

            Assert.True(destructor.EstaDestruida());

        }


    }
}