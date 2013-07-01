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
    public class MinaVista
    {
        private Mina mina;
        private Texture2D imagenMina;
        private VistaTablero vistaTablero;

        public MinaVista(Mina mina, Texture2D imagenMina, VistaTablero vistaTablero)
        {
            this.mina = mina;
            this.imagenMina = imagenMina;
            this.vistaTablero = vistaTablero;
        }
        public void Dibujar(SpriteBatch spriteBatch)
        {
            if (mina.Explotado)
                  return;
            Posicion posicion = mina.Posicion;
            int fila = posicion.Fila;
            int columna = posicion.Columna;
            Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);
            spriteBatch.Draw(imagenMina, posicionDeImagen, Color.White);
        }
    }
}
