using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using NUnit.Framework;

namespace BatallaNavalgo
{
    [TestFixture]
    public class ArmamentoFactoryTest
    {
        [Test]
        /*Comprueba coste de creacion*/
        public void testCreaUnDisparoComunValido()
        {
            Posicion posicion = new Posicion(3, 4);
            DisparoComun disparo = ArmamentoFactory.CrearDisparoComun(posicion);
            Assert.True(disparo.GetCosto() == 200);
        }

        [Test]
        /*Comprueba coste de creacion*/
        public void testCreaUnaMinaPuntualConCostoValido()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaConRetardo mina = ArmamentoFactory.CrearMinaPuntual(posicion);
            Assert.True(mina.GetCosto() == 50);
        }

        [Test]
        /*Comprueba coste de creacion*/
        public void testCreaUnaMinaDobleConCostoValido()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaConRetardo mina = ArmamentoFactory.CrearMinaDoble(posicion);
            Assert.True(mina.GetCosto() == 100);
        }

        [Test]
        /*Comprueba coste de creacion*/
        public void testCreaUnaMinaTripleConCostoValido()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaConRetardo mina = ArmamentoFactory.CrearMinaTriple(posicion);
            Assert.True(mina.GetCosto() == 125);
        }

        [Test]
        /*Comprueba coste de creacion*/
        public void testCreaUnaMinaPorContactoConCostoValido()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaPorContacto disparo = ArmamentoFactory.CrearMinaPorContacto(posicion);
            Assert.True(disparo.GetCosto() == 150);
        }

        [Test]
        /*Comprueba radio*/
        public void testCreaMinaPuntualValida()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaConRetardo mina = ArmamentoFactory.CrearMinaPuntual(posicion);
            Assert.True(mina.GetRadio() == 0);   
        }

        [Test]
        /*Comprueba radio*/
        public void testCreaMinaDobleValida()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaConRetardo mina = ArmamentoFactory.CrearMinaDoble(posicion);
            Assert.True(mina.GetRadio() == 1);
        }

        [Test]
        /*Comprueba radio*/
        public void testCreaMinaTripleValida()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaConRetardo mina = ArmamentoFactory.CrearMinaTriple(posicion);
            Assert.True(mina.GetRadio() == 2);
        }

        [Test]
        /*Comprueba radio*/
        public void testCreaMinaPorContactoValida()
        {
            Posicion posicion = new Posicion(3, 4);
            MinaPorContacto mina = ArmamentoFactory.CrearMinaPorContacto(posicion);
            Assert.True(mina.GetRadio() == 0);
        }
    }
}