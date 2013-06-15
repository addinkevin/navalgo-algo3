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
            posicionTableroEnPantalla = new Vector2(400, 80);
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

        public void DibujarPosicionesDelTablero(SpriteBatch spriteBatch, SpriteFont fuenteBatallaNavalgo)
        {
            int posicionInicialEnX = 70;
            for (int i = 1; i < 11; i++)
            {
                spriteBatch.DrawString(fuenteBatallaNavalgo, "" + i, new Vector2(375, posicionInicialEnX + 15), Color.White);
                spriteBatch.DrawString(fuenteBatallaNavalgo, "" + i, new Vector2(posicionInicialEnX + 340, 55), Color.White);
                posicionInicialEnX = posicionInicialEnX + 40;
            }
        }
    }
}
