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
    public class DibujadorDeNaves
    {
        private SpriteBatch spriteBatch;
        private VistaTablero vistaTablero;
        private Texture2D imagenParteNaveGris, imagenParteNaveRoja, imagenParteNaveVerde, imagenParteNaveMarron, imagenParteNaveRota;

        /*Se le pasa vistaTablero para saber donde tiene que dibujar*/
        public DibujadorDeNaves(SpriteBatch sprite, VistaTablero vistaTablero) 
        {
            this.spriteBatch = sprite;  
            this.vistaTablero = vistaTablero;
        }

        /*Setter de parte.*/
        public Texture2D ParteGris 
        {
            get { return imagenParteNaveGris; }
            set { imagenParteNaveGris = value; }
        }
        /*Setter de parte.*/
        public Texture2D ParteRoja
        {
            get { return imagenParteNaveRoja; }
            set { imagenParteNaveRoja = value; }
        }
        /*Setter de parte.*/
        public Texture2D ParteVerde
        {
            get { return imagenParteNaveVerde; }
            set { imagenParteNaveVerde = value; }
        }
        /*Setter de parte.*/
        public Texture2D ParteMarron
        {
            get { return imagenParteNaveMarron; }
            set { imagenParteNaveMarron = value; }
        }
        /*Setter de parte.*/
        public Texture2D ParteRota
        {
            get { return imagenParteNaveRota; }
            set { imagenParteNaveRota = value; }
        }
        
        public void DibujarNave(Nave nave, Texture2D imagenParte)
        {
            if (nave.EstaDestruida())
                return;
            List<Posicion> posiciones = nave.GetPosiciones();
            foreach (Posicion posicion in posiciones)
            {
                int fila = posicion.Fila;
                int columna = posicion.Columna;
                Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);

                spriteBatch.Begin();
                if (nave.EstaDestruidaEnLaPosicion(posicion))
                {
                    spriteBatch.Draw(imagenParteNaveRota, posicionDeImagen, Color.White);
                }
                else
                {
                    spriteBatch.Draw(imagenParte, posicionDeImagen, Color.White);
                }
                spriteBatch.End();

            }
        }
    }
}
