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
            if ((y > posicionIncialTableroEnY) && (y < posicionFinalTableroEnY))
            {
                if ((x > posicionIncialTableroEnX) && (x < posicionFinalTableroEnX))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D bloqueTablero, SpriteFont fuenteBatallaNavalgo)
        {
            for (int i = 0; i < altoTablero; i++)
            {
                for (int j = 0; j < anchoTablero; j++)
                {
                    int ancho = posicionIncialTableroEnX + (i * tamanioBloqueTablero);
                    int alto = posicionIncialTableroEnY + (j * tamanioBloqueTablero);
                    spriteBatch.Draw(bloqueTablero, new Rectangle(ancho, alto, tamanioBloqueTablero, tamanioBloqueTablero), null, Color.White);
                }
            }
            DibujarPosicionesDelTablero(spriteBatch, fuenteBatallaNavalgo);
        }

        public void DibujarPosicionesDelTablero(SpriteBatch spriteBatch, SpriteFont fuenteBatallaNavalgo)
        {
            int posicionInicialEnX = posicionIncialTableroEnX + 10; //Se suma el 10 en ambas posiciones
            int posicionInicialEnY = posicionIncialTableroEnY + 10; //solo por un tema de vista.
            for (int i = 1; i < 11; i++)
            {
                spriteBatch.DrawString(fuenteBatallaNavalgo, "" + i, new Vector2(375, posicionInicialEnY), Color.White);
                spriteBatch.DrawString(fuenteBatallaNavalgo, "" + i, new Vector2(posicionInicialEnX, 55), Color.White);
                posicionInicialEnX += 40;
                posicionInicialEnY += 40;
            }
        }

        public Vector2 GetPosicionDe(int fila, int columna)
        {
            Vector2 posicionEnPantalla = new Vector2(0,0);
            posicionEnPantalla.X = (posicionIncialTableroEnX + 10) + ((columna - 1) * tamanioBloqueTablero); //Se suma el 10 en ambas posiciones
            posicionEnPantalla.Y = (posicionIncialTableroEnY + 10) + ((fila - 1) * tamanioBloqueTablero); //solo por un tema de vista.

            return posicionEnPantalla;
            
        }
    }
}
