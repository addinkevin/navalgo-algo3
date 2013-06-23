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
    class DibujadorDeNaves
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
            set { imagenParteNaveGris = value; }
        }
        /*Setter de parte.*/
        public Texture2D ParteRoja
        {
            set { imagenParteNaveRoja = value; }
        }
        /*Setter de parte.*/
        public Texture2D ParteVerde
        {
            set { imagenParteNaveVerde = value; }
        }
        /*Setter de parte.*/
        public Texture2D ParteMarron
        {
            set { imagenParteNaveMarron = value; }
        }
        /*Setter de parte.*/
        public Texture2D ParteRota
        {
            set { imagenParteNaveRota = value; }
        }
        

        public void DibujarNaves(SpriteBatch spriteBatch, IEnumerator<Nave> iteradorDeNavesDelJuego)
        {            
            IEnumerator<Nave> recorredorDeNaves = iteradorDeNavesDelJuego;

            while (recorredorDeNaves.MoveNext())
            {
                DibujarUnaNave(spriteBatch, recorredorDeNaves.Current);
            }
        }

        /*Dibuja Nave generica*/
        private void DibujarUnaNave(SpriteBatch spriteBatch, Nave nave)
        {
            if (nave.ObtenerResistenciaGeneral() == 2)
            {
                DibujarUnRompeHielos(spriteBatch, nave);
                return;
            }
            List<Posicion> posiciones = nave.GetPosiciones();
            foreach (Posicion posicion in posiciones)
            {
                int fila = posicion.Fila;
                int columna = posicion.Columna;
                Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);
                
                if (nave.EstaDestruidaEnLaPosicion(posicion))
                {
                    spriteBatch.Draw(imagenParteNaveRota, posicionDeImagen, Color.White);
                }
                else
                {
                    spriteBatch.Draw(imagenParteNaveGris, posicionDeImagen, Color.White);
                }

            }
        }

        /*Dibuja Destructor*/
        private void DibujarUnaNave(SpriteBatch spriteBatch, Destructor nave)
        {
            List<Posicion> posiciones = nave.GetPosiciones();
            foreach (Posicion posicion in posiciones)
            {
                int fila = posicion.Fila;
                int columna = posicion.Columna;
                Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);
                if (nave.EstaDestruidaEnLaPosicion(posicion))
                {
                    spriteBatch.Draw(imagenParteNaveRota, posicionDeImagen, Color.White);
                }
                else
                {                    
                    spriteBatch.Draw(imagenParteNaveRoja, posicionDeImagen, Color.White);
                }
                
            }
        }

        /*Dibuja Buque*/
        private void DibujarUnaNave(SpriteBatch spriteBatch, Buque nave)
        {
            List<Posicion> posiciones = nave.GetPosiciones();
            foreach (Posicion posicion in posiciones)
            {
                int fila = posicion.Fila;
                int columna = posicion.Columna;
                Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);
                if (nave.EstaDestruidaEnLaPosicion(posicion))
                {
                    spriteBatch.Draw(imagenParteNaveRota, posicionDeImagen, Color.White);
                }
                else
                {
                    spriteBatch.Draw(imagenParteNaveVerde, posicionDeImagen, Color.White);
                }
                
            }
        }

        /*Dibuja Rompehielos*/
        private void DibujarUnRompeHielos(SpriteBatch spriteBatch, Nave nave)
        {
            List<Posicion> posiciones = nave.GetPosiciones();
            foreach (Posicion posicion in posiciones)
            {                
                int fila = posicion.Fila;
                int columna = posicion.Columna;
                Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);
                if (nave.EstaDestruidaEnLaPosicion(posicion))
                {
                    spriteBatch.Draw(imagenParteNaveRota, posicionDeImagen, Color.White);
                }
                else
                {                
                    spriteBatch.Draw(imagenParteNaveMarron, posicionDeImagen, Color.White);
                }
            }
        }
    }
}
