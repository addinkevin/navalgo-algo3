using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BatallaNavalgo;

namespace BatallaNavalgoXNA
{
    class VistaTablero
    {
        public Vector2 posicionTableroEnPantalla;
        public int altoTablero;
        public int anchoTablero;
        public Tablero tablero;
        public int tamanioBloqueTablero;

        public VistaTablero()
        {
            tablero = new Tablero();
            altoTablero = Tablero.Filas;
            anchoTablero = Tablero.Columnas;
            posicionTableroEnPantalla = new Vector2(200, 75);
            tamanioBloqueTablero = 40;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D bloqueTablero)
        {
            for (int i = 0; i < altoTablero; i++)
            {
                for (int j = 0; j < anchoTablero; j++)
                {
                    int alto = (int)(posicionTableroEnPantalla.X + (i * tamanioBloqueTablero));
                    int ancho = (int)(posicionTableroEnPantalla.Y + (j * tamanioBloqueTablero));
                    spriteBatch.Draw(bloqueTablero, new Rectangle(alto, ancho, tamanioBloqueTablero, tamanioBloqueTablero), null, Color.White);
                }
            }
        }
    }
}
