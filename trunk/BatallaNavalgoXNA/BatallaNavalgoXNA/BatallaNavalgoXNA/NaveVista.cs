using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BatallaNavalgoXNA
{
    public class NaveVista
    {
        private Nave nave;
        private Texture2D imagenParte;
        private Texture2D imagenParteRota;
        private VistaTablero vistaTablero;

        /*Se le pasa vistaTablero para saber donde tiene que dibujar*/
        public NaveVista(Nave nave, Texture2D imagenParte,Texture2D imagenParteRota, VistaTablero vistaTablero)
        {
            this.nave = nave;
            this.imagenParte = imagenParte;
            this.imagenParteRota = imagenParteRota;
            this.vistaTablero = vistaTablero;
        }

        public void Dibujar(SpriteBatch spriteBatch)
        {
            if (nave.EstaDestruida())
                return;
            List<Posicion> posiciones = nave.GetPosiciones();
            foreach (Posicion posicion in posiciones)
            {
                int fila = posicion.Fila;
                int columna = posicion.Columna;
                Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);

                if (nave.EstaDestruidaEnLaPosicion(posicion))
                {
                    spriteBatch.Draw(imagenParteRota, posicionDeImagen, Color.White);
                }
                else
                {
                    spriteBatch.Draw(imagenParte, posicionDeImagen, Color.White);
                }

            }
        }
    }
}