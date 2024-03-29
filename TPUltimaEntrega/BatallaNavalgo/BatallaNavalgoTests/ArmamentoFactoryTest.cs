﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using NUnit.Framework;

namespace BatallaNavalgoTests
{
    [TestFixture]
    class ArmamentoFactoryTest
    {
        [Test]
        /*Comprueba coste de creacion*/
        public void testCreaUnDisparoComunValido()
        {
            Posicion posicion = new Posicion(3, 4);
            DisparoComun disparo = ArmamentoFactory.CrearDisparoComun(new Tablero(), posicion);
            Assert.True(disparo.Costo == 200);
        }

        [Test]
        /*Comprueba coste de creacion*/
        public void testCreaUnaMinaPuntualConCostoValido()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaConRetardo mina = ArmamentoFactory.CrearMinaPuntual(new Tablero(), posicion);
            Assert.True(mina.Costo == 50);
        }

        [Test]
        /*Comprueba coste de creacion*/
        public void testCreaUnaMinaDobleConCostoValido()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaConRetardo mina = ArmamentoFactory.CrearMinaDoble(new Tablero(), posicion);
            Assert.True(mina.Costo == 100);
        }

        [Test]
        /*Comprueba coste de creacion*/
        public void testCreaUnaMinaTripleConCostoValido()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaConRetardo mina = ArmamentoFactory.CrearMinaTriple(new Tablero(),posicion);
            Assert.True(mina.Costo == 125);
        }

        [Test]
        /*Comprueba coste de creacion*/
        public void testCreaUnaMinaPorContactoConCostoValido()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaPorContacto disparo = ArmamentoFactory.CrearMinaPorContacto(new Tablero(), posicion);
            Assert.True(disparo.Costo == 150);
        }

        [Test]
        /*Comprueba radio*/
        public void testCreaMinaPuntualValida()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaConRetardo mina = ArmamentoFactory.CrearMinaPuntual(new Tablero(), posicion);
            Assert.True(mina.Radio == 0);   
        }

        [Test]
        /*Comprueba radio*/
        public void testCreaMinaDobleValida()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaConRetardo mina = ArmamentoFactory.CrearMinaDoble(new Tablero(), posicion);
            Assert.True(mina.Radio == 1);
        }

        [Test]
        /*Comprueba radio*/
        public void testCreaMinaTripleValida()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaConRetardo mina = ArmamentoFactory.CrearMinaTriple(new Tablero(), posicion);
            Assert.True(mina.Radio == 2);
        }

        [Test]
        /*Comprueba radio*/
        public void testCreaMinaPorContactoValida()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaPorContacto mina = ArmamentoFactory.CrearMinaPorContacto(new Tablero(), posicion);
            Assert.True(mina.Radio == 0);
        }
    }
}