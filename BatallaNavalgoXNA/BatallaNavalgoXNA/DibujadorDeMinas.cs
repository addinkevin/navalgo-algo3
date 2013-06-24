using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using BatallaNavalgo;

namespace BatallaNavalgoXNA
{
    class DibujadorDeMinas
    {
        private SpriteBatch spriteBatch;
        private VistaTablero vistaTablero;
        private Texture2D imagenMinaPuntual, imagenMinaDoble, imagenMinaTriple, imagenMinaContacto;
        public DibujadorDeMinas(SpriteBatch sprite, VistaTablero vista) 
        {
            this.spriteBatch = sprite;
            this.vistaTablero = vista;
        }

        /*setter de imagen de mina*/
        public Texture2D MinaContacto
        {
            set { imagenMinaContacto = value; }
        }

        /*setter de imagen de mina*/
        public Texture2D MinaPuntual
        {
            set { imagenMinaPuntual = value; }
        }

        /*setter de imagen de mina*/
        public Texture2D MinaDoble
        {
            set { imagenMinaDoble = value; }
        }

        /*setter de imagen de mina*/
        public Texture2D MinaTriple
        {
            set { imagenMinaTriple = value; }
        }


        /*Dibuja las minas en el tablero*/
        public void DibujarMinas(SpriteBatch spriteBatch, IEnumerator<Armamento> recorredorDeArmamentosDelJuego)
        {
            IEnumerator<Armamento> recorredorDeArmamentos = recorredorDeArmamentosDelJuego;
            while (recorredorDeArmamentos.MoveNext())
            {
                if (recorredorDeArmamentos.Current.GetType().ToString() == "BatallaNavalgo.MinaPorContacto")
                {
                    DibujarMinaContacto(spriteBatch, (MinaPorContacto)recorredorDeArmamentos.Current);
                }
                if (recorredorDeArmamentos.Current.GetType().ToString() == "BatallaNavalgo.MinaConRetardo")
                {
                    DibujarMinaRetardo(spriteBatch, (MinaConRetardo)recorredorDeArmamentos.Current);
                }
            }
        }

        /*Dibuja mina con retardo, distinto color segun su radio.*/
        private void DibujarMinaRetardo(SpriteBatch spriteBatch, MinaConRetardo mina)
        {
            Posicion posicion = mina.Posicion;
            int fila = posicion.Fila;
            int columna = posicion.Columna;
            Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);
            Texture2D imagenMina = ObtenerImagenDeMinaConretardo(mina);
            spriteBatch.Draw(imagenMina, posicionDeImagen, Color.White);
        }

        /*Dibuja mina por contacto*/
        private void DibujarMinaContacto(SpriteBatch spriteBatch, MinaPorContacto mina)
        {
            Posicion posicion = mina.Posicion;
            int fila = posicion.Fila;
            int columna = posicion.Columna;
            Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);
            Texture2D imagenMina = imagenMinaContacto;
            spriteBatch.Draw(imagenMina, posicionDeImagen, Color.White);
        }

        /*Obtiene textura de mina segun su radio.*/
        private Texture2D ObtenerImagenDeMinaConretardo(MinaConRetardo mina)
        {
            int radio = mina.Radio;
            switch (radio)
            {
                case 0:
                    return imagenMinaPuntual;
                    break;
                case 1:
                    return imagenMinaDoble;
                    break;
                case 2:
                    return imagenMinaTriple;
                    break;
                default:
                    return imagenMinaPuntual;
                    break;
            }
        }
    }
}
