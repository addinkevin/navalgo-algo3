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
        private Vector2 posicionTableroEnPantalla;
        private int altoTablero;
        private int anchoTablero;
        private Tablero tablero;
        public int tamanioBloqueTablero;
        public int posicionIncialTableroEnX;
        public int posicionIncialTableroEnY;
        private int posicionFinalTableroEnX;
        private int posicionFinalTableroEnY;

        public VistaTablero()
        {
            tablero = new Tablero();
            altoTablero = Tablero.Filas;
            anchoTablero = Tablero.Columnas;
            posicionTableroEnPantalla = new Vector2(400, 80);
            tamanioBloqueTablero = 40;
            posicionIncialTableroEnX = (int)posicionTableroEnPantalla.X;
            posicionIncialTableroEnY = (int)posicionTableroEnPantalla.Y;
            posicionFinalTableroEnX = (int)posicionIncialTableroEnX + (tamanioBloqueTablero * anchoTablero);
            posicionFinalTableroEnY = (int)posicionIncialTableroEnY + (tamanioBloqueTablero * altoTablero);
        }

        public Boolean EstaDentroDelTablero(int x, int y)
        {
            if (y > posicionIncialTableroEnY)
            {
                if (y < posicionFinalTableroEnY)
                {
                    if (x > posicionIncialTableroEnX)
                    {
                        if (x < posicionFinalTableroEnX)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
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
